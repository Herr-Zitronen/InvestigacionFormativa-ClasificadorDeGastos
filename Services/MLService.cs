using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML; // IA Integrada
using Microsoft.ML.Data;
using _2InvestigacionFormativa.Models;

namespace _2InvestigacionFormativa.Services
{
    public class MLService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;
        private PredictionEngine<GastoInput, GastoPrediction> _predictionEngine;
        private string[] _slotNamesCache;
        private const string RutaModeloPorDefecto = "modelo_gastos.zip";

        public DateTime? UltimaFechaEntrenamiento { get; private set; }
        public int TotalEjemplosEntrenados { get; private set; }

        public MLService()
        {
            _mlContext = new MLContext(seed: 42);

            if (File.Exists(RutaModeloPorDefecto))
            {
                try
                {
                    CargarModelo(RutaModeloPorDefecto);
                }
                catch
                {
                    // Si el archivo del modelo está corrupto o es de una versión anterior, reentrenar
                    EntrenarModelo(SembrarDatosEntrenamiento(), guardarEnDisco: true);
                }
            }
            else
            {
                EntrenarModelo(SembrarDatosEntrenamiento(), guardarEnDisco: true);
            }
        }

        public List<GastoInput> SembrarDatosEntrenamiento()
        {
            return new List<GastoInput>
            {
                // Categoría: Alimentación (10 ejemplos)
                new GastoInput { Descripcion = "Compra en supermercado Éxito", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Almuerzo en restaurante campestre", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Pizza familiar y gaseosas a domicilio", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Pan y leche en panadería", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Cena gourmet de fin de semana", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Hamburguesas con papas fritas", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Mercado de carnes, frutas y verduras", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Café espresso y pastel de queso", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Pedido de comida delivery Rappi", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Desayuno buffet de café y huevos", Categoria = "Alimentación" },

                // Categoría: Transporte (10 ejemplos)
                new GastoInput { Descripcion = "Viaje en taxi al centro", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Recarga tarjeta del metro y transmilenio", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Tanqueada de gasolina para vehículo", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Tarifa viaje aplicación Uber", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Pago peaje en autopista nacional", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Pasaje de autobús intermunicipal", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Mantenimiento y cambio aceite moto", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Estacionamiento de vehículo por horas", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Compra de combustible Diésel para auto", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Carrera de taxi nocturna", Categoria = "Transporte" },

                // Categoría: Servicios (9 ejemplos)
                new GastoInput { Descripcion = "Pago de factura de energía y luz", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Recibo mensual de agua potable y acueducto", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Factura de servicio de gas natural domiciliario", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Mensualidad internet fibra óptica y telefonía fija", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Plan pospago telefonía móvil celular", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Pago de administración del edificio de apartamentos", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Factura de aseo y recolección de basura", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Recibo electricidad Enel mensual", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Recarga de datos móviles prepago", Categoria = "Servicios" },

                // Categoría: Entretenimiento (10 ejemplos)
                new GastoInput { Descripcion = "Entradas para cine y palomitas", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Suscripción mensual a Netflix", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Membresía anual Spotify Premium", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Compra de juego digital en Steam", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Boletas para concierto de música en vivo", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Salida a bar y bebidas con amigos", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Entradas parque temático de diversiones", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Suscripción plataforma Disney Plus", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Tarde de bolos y juegos arcade", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Boleta para partido de fútbol en estadio", Categoria = "Entretenimiento" },

                // Categoría: Salud y Educación (10 ejemplos)
                new GastoInput { Descripcion = "Consulta médica general en clínica privada", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Compra medicamentos e ibuprofeno en farmacia", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Cita odontólogo para limpieza y calzas", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Exámenes de laboratorio clínico y sangre", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Matrícula semestre de universidad", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Compra libros de texto académicos y cuadernos", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Pago curso de programación virtual", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Visita consulta pediátrica infantil", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Lentes formulados en óptica", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Remedios jarabe para la tos y vitaminas", Categoria = "Salud y Educación" }
            };
        }

        public void EntrenarModelo(List<GastoInput> datos, bool guardarEnDisco = true)
        {
            if (datos == null || datos.Count == 0)
                datos = SembrarDatosEntrenamiento();

            var dataView = _mlContext.Data.LoadFromEnumerable(datos);

            var pipeline = _mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(GastoInput.Descripcion))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label", inputColumnName: nameof(GastoInput.Categoria)))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedLabel", inputColumnName: "PredictedLabel"));

            _model = pipeline.Fit(dataView);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<GastoInput, GastoPrediction>(_model);
            _slotNamesCache = ObtenerNombresRanurasScore();
            TotalEjemplosEntrenados = datos.Count;
            UltimaFechaEntrenamiento = DateTime.Now;

            if (guardarEnDisco)
            {
                GuardarModelo(RutaModeloPorDefecto, dataView.Schema);
            }
        }

        public void GuardarModelo(string ruta, DataViewSchema schema = null)
        {
            try
            {
                if (schema == null)
                {
                    var dataView = _mlContext.Data.LoadFromEnumerable(SembrarDatosEntrenamiento());
                    schema = dataView.Schema;
                }
                _mlContext.Model.Save(_model, schema, ruta);
            }
            catch
            {
                // Silencioso si no se puede escribir
            }
        }

        public void CargarModelo(string ruta)
        {
            DataViewSchema schema;
            _model = _mlContext.Model.Load(ruta, out schema);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<GastoInput, GastoPrediction>(_model);
            _slotNamesCache = ObtenerNombresRanurasScore();
            UltimaFechaEntrenamiento = File.GetLastWriteTime(ruta);
            TotalEjemplosEntrenados = SembrarDatosEntrenamiento().Count;
        }

        private string[] ObtenerNombresRanurasScore()
        {
            try
            {
                if (_predictionEngine != null)
                {
                    var column = _predictionEngine.OutputSchema["Score"];
                    VBuffer<ReadOnlyMemory<char>> keys = default;
                    column.Annotations.GetValue("SlotNames", ref keys);
                    return keys.DenseValues().Select(v => v.ToString()).ToArray();
                }
            }
            catch
            {
                // Alternativa estándar
            }

            return new[] { "Alimentación", "Transporte", "Servicios", "Entretenimiento", "Salud y Educación" };
        }

        public PrediccionResultado PredecirDetalle(string descripcion)
        {
            var resultado = new PrediccionResultado
            {
                Categoria = string.Empty,
                Confianza = 0.0
            };

            if (string.IsNullOrWhiteSpace(descripcion))
                return resultado;

            if (_predictionEngine == null)
            {
                EntrenarModelo(SembrarDatosEntrenamiento());
            }

            var input = new GastoInput { Descripcion = descripcion };
            var prediccion = _predictionEngine.Predict(input);

            if (prediccion == null || string.IsNullOrEmpty(prediccion.PredictedLabel))
                return resultado;

            resultado.Categoria = prediccion.PredictedLabel;

            // Calcular probabilidades Softmax a partir del array Score
            if (prediccion.Score != null && prediccion.Score.Length > 0)
            {
                double[] probabilidades = CalcularSoftmax(prediccion.Score);
                string[] etiquetas = _slotNamesCache ?? ObtenerNombresRanurasScore();

                int indiceGanador = -1;
                double maxProb = 0.0;

                for (int i = 0; i < probabilidades.Length; i++)
                {
                    string etiqueta = (etiquetas != null && i < etiquetas.Length) ? etiquetas[i] : $"Clase_{i}";
                    resultado.DistribucionProbabilidades[etiqueta] = probabilidades[i];

                    if (string.Equals(etiqueta, prediccion.PredictedLabel, StringComparison.OrdinalIgnoreCase))
                    {
                        indiceGanador = i;
                        maxProb = probabilidades[i];
                    }
                    else if (probabilidades[i] > maxProb && indiceGanador == -1)
                    {
                        maxProb = probabilidades[i];
                    }
                }

                resultado.Confianza = indiceGanador >= 0 ? probabilidades[indiceGanador] : maxProb;
            }
            else
            {
                resultado.Confianza = 0.5;
            }

            return resultado;
        }

        public string Predecir(string descripcion)
        {
            return PredecirDetalle(descripcion).Categoria;
        }

        private static double[] CalcularSoftmax(float[] scores)
        {
            if (scores == null || scores.Length == 0) return new double[0];

            float max = scores.Max();
            double sum = 0.0;
            double[] exp = new double[scores.Length];

            for (int i = 0; i < scores.Length; i++)
            {
                exp[i] = Math.Exp(scores[i] - max);
                sum += exp[i];
            }

            for (int i = 0; i < scores.Length; i++)
            {
                exp[i] = sum > 0 ? (exp[i] / sum) : (1.0 / scores.Length);
            }

            return exp;
        }

        public int EntrenarConDatosBaseYConfirmados(List<GastoInput> datosConfirmados)
        {
            var baseDatos = SembrarDatosEntrenamiento();
            var conjunto = new Dictionary<string, GastoInput>(StringComparer.OrdinalIgnoreCase);

            // Primero los datos base
            foreach (var b in baseDatos)
            {
                conjunto[b.Descripcion.Trim()] = b;
            }

            // Sobrescribir o añadir con los datos confirmados del usuario
            if (datosConfirmados != null)
            {
                foreach (var c in datosConfirmados)
                {
                    if (!string.IsNullOrWhiteSpace(c.Descripcion) && !string.IsNullOrWhiteSpace(c.Categoria))
                    {
                        conjunto[c.Descripcion.Trim()] = new GastoInput
                        {
                            Descripcion = c.Descripcion.Trim(),
                            Categoria = c.Categoria.Trim()
                        };
                    }
                }
            }

            var listaFinal = conjunto.Values.ToList();
            EntrenarModelo(listaFinal, guardarEnDisco: true);
            return listaFinal.Count;
        }

        public ResultadoEvaluacion EvaluarMetricas()
        {
            // 20 casos de prueba fijos no incluidos en el entrenamiento base
            var casosPrueba = new List<GastoInput>
            {
                // Alimentación (4 casos)
                new GastoInput { Descripcion = "Almuerzo ejecutivo en restaurante con compañeros", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Mercado de compras en Carulla con frutas", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Porción de pizza con queso y refresco", Categoria = "Alimentación" },
                new GastoInput { Descripcion = "Panes y café en la panadería", Categoria = "Alimentación" },

                // Transporte (4 casos)
                new GastoInput { Descripcion = "Carrera de taxi al aeropuerto", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Tanque lleno de gasolina corriente estación", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Viaje en Uber express hacia la oficina", Categoria = "Transporte" },
                new GastoInput { Descripcion = "Pago peaje de carretera vía autopista", Categoria = "Transporte" },

                // Servicios (4 casos)
                new GastoInput { Descripcion = "Factura de luz eléctrica del mes", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Pago de recibo de agua potable acueducto", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Internet fibra óptica hogar y telefonía", Categoria = "Servicios" },
                new GastoInput { Descripcion = "Factura mensual de gas natural domiciliario", Categoria = "Servicios" },

                // Entretenimiento (4 casos)
                new GastoInput { Descripcion = "Entradas de cine y combo de palomitas", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Mensualidad suscripción de Netflix", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Suscripción a Spotify música sin anuncios", Categoria = "Entretenimiento" },
                new GastoInput { Descripcion = "Compra de videojuego aventura en Steam", Categoria = "Entretenimiento" },

                // Salud y Educación (4 casos)
                new GastoInput { Descripcion = "Consulta médica especialista particular", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Antibióticos y pastillas en la farmacia", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Matrícula de curso universitario de inglés", Categoria = "Salud y Educación" },
                new GastoInput { Descripcion = "Limpieza dental en consultorio odontólogo", Categoria = "Salud y Educación" }
            };

            var categorias = new List<string> { "Alimentación", "Transporte", "Servicios", "Entretenimiento", "Salud y Educación" };
            int n = categorias.Count;
            var matriz = new int[n, n];

            var resultado = new ResultadoEvaluacion
            {
                TotalCasos = casosPrueba.Count,
                Aciertos = 0,
                Categorias = categorias,
                MatrizConfusion = matriz
            };

            foreach (var caso in casosPrueba)
            {
                var predDetalle = PredecirDetalle(caso.Descripcion);
                string predicha = predDetalle.Categoria;
                bool esAcierto = string.Equals(predicha?.Trim(), caso.Categoria?.Trim(), StringComparison.OrdinalIgnoreCase);

                if (esAcierto)
                {
                    resultado.Aciertos++;
                }

                int idxReal = categorias.FindIndex(c => string.Equals(c, caso.Categoria, StringComparison.OrdinalIgnoreCase));
                int idxPred = categorias.FindIndex(c => string.Equals(c, predicha, StringComparison.OrdinalIgnoreCase));

                if (idxReal >= 0 && idxPred >= 0)
                {
                    matriz[idxReal, idxPred]++;
                }

                resultado.Detalles.Add(new DetalleEvaluacion
                {
                    Descripcion = caso.Descripcion,
                    CategoriaReal = caso.Categoria,
                    CategoriaPredicha = predicha,
                    Confianza = predDetalle.Confianza,
                    Acierto = esAcierto ? "Sí" : "No"
                });
            }

            resultado.PorcentajeExactitud = resultado.TotalCasos > 0
                ? Math.Round(((double)resultado.Aciertos / resultado.TotalCasos) * 100.0, 2)
                : 0.0;

            resultado.MicroAccuracy = resultado.TotalCasos > 0 ? ((double)resultado.Aciertos / resultado.TotalCasos) : 0.0;
            resultado.MacroAccuracy = resultado.MicroAccuracy; // Balanceado con 4 casos por categoría

            return resultado;
        }
    }
}
