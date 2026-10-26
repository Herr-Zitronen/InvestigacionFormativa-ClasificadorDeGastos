# Escuela Superior Politécnica de Chimborazo (ESPOCH)
## Facultad de Informática y Electrónica
### Aplicaciones Informáticas — 5to Semestre

---

# Clasificador Inteligente de Gastos con Machine Learning (ML.NET) y SQLite

Proyecto de investigación formativa consistente en el desarrollo de una aplicación de escritorio orientada a la gestión financiera personal con categorización inteligente de transacciones en tiempo real, respaldada por un modelo de Machine Learning local y almacenamiento persistente en SQLite.

---

## 👥 Integrantes del Proyecto
- **Joel Guerrero**
- **Jhenny López**

## 👩‍🏫 Docente
- **Ing. Lorena Aguirre**

---

## 📌 Descripción General del Proyecto

La aplicación resuelve la fricción y el error humano en el registro y categorización manual de gastos financieros. Al escribir conceptos como *"Almuerzo ejecutivo"*, el sistema predice en tiempo real la categoría correspondiente (*Alimentación*), evalúa el porcentaje de certeza de dicha predicción mediante funciones de probabilidad calibrada y permite al usuario confirmar o corregir el registro, retroalimentando al modelo mediante **aprendizaje continuo**.

### Características Principales:
1. **Dashboard Financiero Interactivo:** Tarjetas de métricas clave (KPIs), Gráficos de Dona y Barras generados con `System.Windows.Forms.DataVisualization`, y resumen con filtros de fechas.
2. **Clasificación Inteligente en Tiempo Real:** Sugerencia automática con control de rebote (*Debounce Timer* de 400 ms) para optimizar el rendimiento de la CPU.
3. **Persistencia Local Segura:** Base de datos relacional embebida SQLite (`gastos.db`) con consultas parametrizadas contra inyección SQL.
4. **Validación Científica del Modelo:** Evaluación con 20 casos de prueba no vistos por el entrenamiento, cálculo de Exactitud (*Accuracy*) y Matriz de Confusión interactiva.
5. **Aprendizaje Activo (Active Learning):** Capacidad de enseñar nuevos ejemplos y reentrenar el modelo con los gastos confirmados por el usuario sin pérdida de datos base.
6. **Modo Pruebas por Consola (`--test`):** Ejecución automatizada de pruebas sin interfaz gráfica que genera un reporte en `test_results.txt`.
7. **Exportación de Datos:** Exportación del historial de transacciones a formato CSV.

---

## 🛠️ Tecnologías y Librerías Utilizadas

| Tecnología / Librería | Versión | Rol en el Proyecto |
| :--- | :--- | :--- |
| **C# / .NET Framework** | `4.7.2 (x64)` | Lenguaje y entorno de ejecución principal de la solución. |
| **Windows Forms (WinForms)** | Integrado | Capa de interfaz gráfica de usuario. |
| **Microsoft.ML** | `5.0.1` | Motor de Machine Learning para procesamiento de lenguaje natural (NLP) y clasificación multiclase. |
| **System.Data.SQLite** | `2.0.4` | Motor de base de datos relacional local (`gastos.db`). |
| **DataVisualization** | .NET Assembly | Renderizado de gráficos estadísticos (Dona y Barras). |

---

## 🧠 Arquitectura de Machine Learning

- **Transformador de Texto:** `FeaturizeText` (Normalización, tokenización en n-gramas y vectorización TF-IDF).
- **Algoritmo Clasificador:** `SdcaMaximumEntropy` (Descenso de Coordenadas Dual Estocástico con Máxima Entropía), ideal para vectores de texto dispersos y entrenamiento rápido en local.
- **Función de Activación:** Cálculo de **Softmax** numéricamente estable sobre el vector de *Scores* para obtener porcentajes de confianza reales (0% a 100%).
- **Persistencia del Modelo:** Serialización del modelo entrenado en `modelo_gastos.zip`.

---

## 🚀 Requisitos e Instalación

### Requisitos Previos:
- Sistema Operativo: Windows 10 / 11 (64-bit).
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) o superior.
- Visual Studio 2022 (con la carga de trabajo de desarrollo de escritorio de .NET) o .NET SDK.

### Pasos para Ejecutar:

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/Herr-Zitronen/InvestigacionFormativa-ClasificadorDeGastos.git
   cd InvestigacionFormativa-ClasificadorDeGastos
   ```

2. **Compilar y restaurar dependencias:**
   ```bash
   dotnet build
   ```

3. **Ejecutar la aplicación gráfica:**
   ```bash
   .\bin\Debug\2InvestigacionFormativa.exe
   ```

## 📁 Estructura del Código

```text
├── Models/
│   ├── GastoML.cs             # DTOs para ML.NET, probabilidades y métricas
│   └── Transaccion.cs         # Entidad de transacción financiera para SQLite
├── Services/
│   ├── DatabaseService.cs     # Acceso a datos SQLite (CRUD y consultas de agregación)
│   └── MLService.cs           # Pipeline ML.NET, Softmax, evaluación y entrenamiento continuo
├── Form1.cs                   # Lógica de la interfaz gráfica (Dashboard, Registro, Métricas, Entrenamiento)
├── Program.cs                 # Punto de entrada dual (GUI / Modo consola --test)
├── gastos.db                  # Base de datos SQLite preconfigurada con datos de prueba
├── modelo_gastos.zip          # Modelo entrenado y serializado
└── test_results.txt           # Reporte de ejecución de pruebas
```

---
