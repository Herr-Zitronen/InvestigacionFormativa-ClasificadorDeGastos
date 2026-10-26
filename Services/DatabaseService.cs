using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using _2InvestigacionFormativa.Models;

namespace _2InvestigacionFormativa.Services
{
    public class DatabaseService
    {
        private const string CadenaConexion = "Data Source=gastos.db;Version=3;";

        public DatabaseService()
        {
            InicializarBaseDatos();
        }

        private void InicializarBaseDatos()
        {
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();

                string sqlTransacciones = @"
                    CREATE TABLE IF NOT EXISTS Transacciones (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Fecha TEXT NOT NULL,
                        Descripcion TEXT NOT NULL,
                        Monto REAL NOT NULL,
                        CategoriaSugeridaIA TEXT,
                        CategoriaConfirmada TEXT NOT NULL,
                        ConfianzaIA REAL DEFAULT 0
                    );";

                using (var comando = new SQLiteCommand(sqlTransacciones, conexion))
                {
                    comando.ExecuteNonQuery();
                }

                // Migración para bases de datos existentes sin la columna ConfianzaIA
                try
                {
                    string sqlMigracion = "ALTER TABLE Transacciones ADD COLUMN ConfianzaIA REAL DEFAULT 0;";
                    using (var cmd = new SQLiteCommand(sqlMigracion, conexion))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    // La columna ya existe
                }

                string sqlEjemplos = @"
                    CREATE TABLE IF NOT EXISTS EjemplosPersonalizados (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Descripcion TEXT NOT NULL,
                        Categoria TEXT NOT NULL
                    );";

                using (var comando = new SQLiteCommand(sqlEjemplos, conexion))
                {
                    comando.ExecuteNonQuery();
                }

                // Si la tabla de transacciones está vacía, sembrar ejemplos realistas iniciales
                string sqlConteo = "SELECT COUNT(*) FROM Transacciones;";
                using (var cmdConteo = new SQLiteCommand(sqlConteo, conexion))
                {
                    long total = Convert.ToInt64(cmdConteo.ExecuteScalar());
                    if (total == 0)
                    {
                        SembrarGastosIniciales(conexion);
                    }
                }
            }
        }

        private void SembrarGastosIniciales(SQLiteConnection conexion)
        {
            var hoy = DateTime.Now;
            var ejemplos = new[]
            {
                new { Desc = "Mercado quincenal en Supermercado", Monto = 245000.0, Cat = "Alimentación", Conf = 0.94, DiasAtras = 1 },
                new { Desc = "Almuerzo ejecutivo en restaurante", Monto = 24000.0, Cat = "Alimentación", Conf = 0.88, DiasAtras = 2 },
                new { Desc = "Gasolina para vehículo en estación", Monto = 95000.0, Cat = "Transporte", Conf = 0.91, DiasAtras = 3 },
                new { Desc = "Recarga tarjeta transporte masivo metro", Monto = 30000.0, Cat = "Transporte", Conf = 0.85, DiasAtras = 4 },
                new { Desc = "Factura mensual de luz y energía", Monto = 84000.0, Cat = "Servicios", Conf = 0.92, DiasAtras = 5 },
                new { Desc = "Mensualidad internet fibra óptica", Monto = 78000.0, Cat = "Servicios", Conf = 0.89, DiasAtras = 6 },
                new { Desc = "Suscripción mensual Netflix", Monto = 38900.0, Cat = "Entretenimiento", Conf = 0.95, DiasAtras = 7 },
                new { Desc = "Salida a cine y combo de confitería", Monto = 45000.0, Cat = "Entretenimiento", Conf = 0.90, DiasAtras = 8 },
                new { Desc = "Consulta médica general particular", Monto = 65000.0, Cat = "Salud y Educación", Conf = 0.86, DiasAtras = 9 },
                new { Desc = "Compra de medicamentos en farmacia", Monto = 42000.0, Cat = "Salud y Educación", Conf = 0.89, DiasAtras = 10 },
                new { Desc = "Libro de investigación y metodología", Monto = 55000.0, Cat = "Salud y Educación", Conf = 0.84, DiasAtras = 11 }
            };

            foreach (var ej in ejemplos)
            {
                string sqlInsert = @"
                    INSERT INTO Transacciones (Fecha, Descripcion, Monto, CategoriaSugeridaIA, CategoriaConfirmada, ConfianzaIA)
                    VALUES (@Fecha, @Descripcion, @Monto, @CategoriaSugeridaIA, @CategoriaConfirmada, @ConfianzaIA);";

                using (var cmd = new SQLiteCommand(sqlInsert, conexion))
                {
                    cmd.Parameters.AddWithValue("@Fecha", hoy.AddDays(-ej.DiasAtras).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Descripcion", ej.Desc);
                    cmd.Parameters.AddWithValue("@Monto", ej.Monto);
                    cmd.Parameters.AddWithValue("@CategoriaSugeridaIA", ej.Cat);
                    cmd.Parameters.AddWithValue("@CategoriaConfirmada", ej.Cat);
                    cmd.Parameters.AddWithValue("@ConfianzaIA", ej.Conf);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GuardarTransaccion(Transaccion t)
        {
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = @"
                    INSERT INTO Transacciones (Fecha, Descripcion, Monto, CategoriaSugeridaIA, CategoriaConfirmada, ConfianzaIA)
                    VALUES (@Fecha, @Descripcion, @Monto, @CategoriaSugeridaIA, @CategoriaConfirmada, @ConfianzaIA);";

                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Fecha", t.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    comando.Parameters.AddWithValue("@Descripcion", t.Descripcion ?? string.Empty);
                    comando.Parameters.AddWithValue("@Monto", Convert.ToDouble(t.Monto));
                    comando.Parameters.AddWithValue("@CategoriaSugeridaIA", (object)t.CategoriaSugeridaIA ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@CategoriaConfirmada", t.CategoriaConfirmada ?? string.Empty);
                    comando.Parameters.AddWithValue("@ConfianzaIA", t.ConfianzaIA);
                    comando.ExecuteNonQuery();
                    t.Id = (int)conexion.LastInsertRowId;
                }
            }
        }

        public void ActualizarTransaccion(Transaccion t)
        {
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = @"
                    UPDATE Transacciones 
                    SET Fecha = @Fecha, 
                        Descripcion = @Descripcion, 
                        Monto = @Monto, 
                        CategoriaSugeridaIA = @CategoriaSugeridaIA, 
                        CategoriaConfirmada = @CategoriaConfirmada, 
                        ConfianzaIA = @ConfianzaIA
                    WHERE Id = @Id;";

                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", t.Id);
                    comando.Parameters.AddWithValue("@Fecha", t.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    comando.Parameters.AddWithValue("@Descripcion", t.Descripcion ?? string.Empty);
                    comando.Parameters.AddWithValue("@Monto", Convert.ToDouble(t.Monto));
                    comando.Parameters.AddWithValue("@CategoriaSugeridaIA", (object)t.CategoriaSugeridaIA ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@CategoriaConfirmada", t.CategoriaConfirmada ?? string.Empty);
                    comando.Parameters.AddWithValue("@ConfianzaIA", t.ConfianzaIA);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Transaccion> ObtenerTransacciones(string filtroTexto = null, string categoria = null, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var transacciones = new List<Transaccion>();
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                var sql = "SELECT Id, Fecha, Descripcion, Monto, CategoriaSugeridaIA, CategoriaConfirmada, ConfianzaIA FROM Transacciones WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(filtroTexto))
                {
                    sql += " AND LOWER(Descripcion) LIKE @filtroTexto";
                }

                if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas")
                {
                    sql += " AND CategoriaConfirmada = @categoria";
                }

                if (fechaInicio.HasValue)
                {
                    sql += " AND Fecha >= @fechaInicio";
                }

                if (fechaFin.HasValue)
                {
                    sql += " AND Fecha <= @fechaFin";
                }

                sql += " ORDER BY Fecha DESC, Id DESC;";

                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtroTexto))
                    {
                        comando.Parameters.AddWithValue("@filtroTexto", "%" + filtroTexto.Trim().ToLower() + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas")
                    {
                        comando.Parameters.AddWithValue("@categoria", categoria.Trim());
                    }

                    if (fechaInicio.HasValue)
                    {
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio.Value.ToString("yyyy-MM-dd 00:00:00"));
                    }

                    if (fechaFin.HasValue)
                    {
                        comando.Parameters.AddWithValue("@fechaFin", fechaFin.Value.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var t = new Transaccion
                            {
                                Id = Convert.ToInt32(lector["Id"]),
                                Fecha = DateTime.TryParse(lector["Fecha"]?.ToString(), out var f) ? f : DateTime.Now,
                                Descripcion = lector["Descripcion"]?.ToString() ?? string.Empty,
                                Monto = Convert.ToDecimal(lector["Monto"]),
                                CategoriaSugeridaIA = lector["CategoriaSugeridaIA"] != DBNull.Value ? lector["CategoriaSugeridaIA"].ToString() : string.Empty,
                                CategoriaConfirmada = lector["CategoriaConfirmada"]?.ToString() ?? string.Empty,
                                ConfianzaIA = lector["ConfianzaIA"] != DBNull.Value ? Convert.ToDouble(lector["ConfianzaIA"]) : 0.0
                            };
                            transacciones.Add(t);
                        }
                    }
                }
            }
            return transacciones;
        }

        public void EliminarTransaccion(int id)
        {
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = "DELETE FROM Transacciones WHERE Id = @Id;";
                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ResumenCategoria> ObtenerResumenPorCategoria(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var lista = new List<ResumenCategoria>();
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                var sql = @"
                    SELECT CategoriaConfirmada, SUM(Monto) AS TotalMonto, COUNT(*) AS Cantidad
                    FROM Transacciones
                    WHERE 1=1";

                if (fechaInicio.HasValue)
                {
                    sql += " AND Fecha >= @fechaInicio";
                }

                if (fechaFin.HasValue)
                {
                    sql += " AND Fecha <= @fechaFin";
                }

                sql += @"
                    GROUP BY CategoriaConfirmada
                    ORDER BY TotalMonto DESC;";

                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    if (fechaInicio.HasValue)
                    {
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio.Value.ToString("yyyy-MM-dd 00:00:00"));
                    }

                    if (fechaFin.HasValue)
                    {
                        comando.Parameters.AddWithValue("@fechaFin", fechaFin.Value.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new ResumenCategoria
                            {
                                Categoria = lector["CategoriaConfirmada"]?.ToString() ?? "Sin Categoría",
                                TotalMonto = Convert.ToDecimal(lector["TotalMonto"]),
                                CantidadTransacciones = Convert.ToInt32(lector["Cantidad"])
                            });
                        }
                    }
                }
            }

            decimal totalGeneral = lista.Sum(r => r.TotalMonto);
            if (totalGeneral > 0)
            {
                foreach (var item in lista)
                {
                    item.PorcentajeDelTotal = (double)((item.TotalMonto / totalGeneral) * 100m);
                }
            }

            return lista;
        }

        public List<GastoInput> ObtenerGastosConfirmadosParaEntrenamiento()
        {
            var lista = new List<GastoInput>();
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = @"
                    SELECT Descripcion, CategoriaConfirmada 
                    FROM Transacciones 
                    WHERE TRIM(Descripcion) != '' AND TRIM(CategoriaConfirmada) != ''
                    GROUP BY LOWER(TRIM(Descripcion)), CategoriaConfirmada;";

                using (var comando = new SQLiteCommand(sql, conexion))
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new GastoInput
                        {
                            Descripcion = lector["Descripcion"]?.ToString()?.Trim() ?? string.Empty,
                            Categoria = lector["CategoriaConfirmada"]?.ToString()?.Trim() ?? string.Empty
                        });
                    }
                }
            }
            return lista;
        }

        public void GuardarEjemploPersonalizado(string descripcion, string categoria)
        {
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = "INSERT INTO EjemplosPersonalizados (Descripcion, Categoria) VALUES (@Descripcion, @Categoria);";
                using (var comando = new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Descripcion", descripcion.Trim());
                    comando.Parameters.AddWithValue("@Categoria", categoria.Trim());
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<GastoInput> ObtenerEjemplosPersonalizados()
        {
            var lista = new List<GastoInput>();
            using (var conexion = new SQLiteConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = "SELECT Descripcion, Categoria FROM EjemplosPersonalizados ORDER BY Id DESC;";
                using (var comando = new SQLiteCommand(sql, conexion))
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new GastoInput
                        {
                            Descripcion = lector["Descripcion"]?.ToString() ?? string.Empty,
                            Categoria = lector["Categoria"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }
            return lista;
        }
    }
}
