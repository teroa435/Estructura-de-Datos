using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

class Program
{
    static void Main()
    {
        // ────────── 1. Generar 500 ciudadanos ficticios ──────────
        var ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // ────────── 2. Generar vacunados Pfizer (75) ──────────
        var vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"Ciudadano {i}");
        }

        // ────────── 3. Generar vacunados AstraZeneca (75) ──────────
        var vacunadosAstra = new HashSet<string>();
        for (int i = 50; i < 125; i++)
        {
            vacunadosAstra.Add($"Ciudadano {i}");
        }

        // ────────── 4. Operaciones de conjuntos ──────────

        // A. Ciudadanos no vacunados
        var vacunados = new HashSet<string>(vacunadosPfizer.Union(vacunadosAstra));
        var noVacunados = new HashSet<string>(ciudadanos.Except(vacunados));

        // B. Ciudadanos con ambas dosis (Pfizer ∩ AstraZeneca)
        var ambasDosis = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstra));

        // C. Solo Pfizer
        var soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstra));

        // D. Solo AstraZeneca
        var soloAstra = new HashSet<string>(vacunadosAstra.Except(vacunadosPfizer));

        // ────────── 5. Mostrar en consola ──────────
        Console.WriteLine("---- Ciudadanos NO vacunados ----");
        Console.WriteLine(string.Join(", ", noVacunados));

        Console.WriteLine("\n---- Ciudadanos con ambas dosis ----");
        Console.WriteLine(string.Join(", ", ambasDosis));

        Console.WriteLine("\n---- Ciudadanos SOLO Pfizer ----");
        Console.WriteLine(string.Join(", ", soloPfizer));

        Console.WriteLine("\n---- Ciudadanos SOLO AstraZeneca ----");
        Console.WriteLine(string.Join(", ", soloAstra));

        // ────────── 6. Generar Reporte PDF ──────────
        GenerarPDF(noVacunados, ambasDosis, soloPfizer, soloAstra);
    }

    static void GenerarPDF(HashSet<string> noVacunados, HashSet<string> ambasDosis,
                           HashSet<string> soloPfizer, HashSet<string> soloAstra)
    {
        Document doc = new Document(PageSize.A4);
        string ruta = "ReporteVacunacion.pdf";

        using (var writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create)))
        {
            doc.Open();

            doc.Add(new Paragraph("📊 Reporte de Vacunación COVID-19\n\n"));
            doc.Add(new Paragraph("---- Ciudadanos NO vacunados ----"));
            doc.Add(new Paragraph(string.Join(", ", noVacunados) + "\n\n"));

            doc.Add(new Paragraph("---- Ciudadanos con ambas dosis ----"));
            doc.Add(new Paragraph(string.Join(", ", ambasDosis) + "\n\n"));

            doc.Add(new Paragraph("---- Ciudadanos SOLO Pfizer ----"));
            doc.Add(new Paragraph(string.Join(", ", soloPfizer) + "\n\n"));

            doc.Add(new Paragraph("---- Ciudadanos SOLO AstraZeneca ----"));
            doc.Add(new Paragraph(string.Join(", ", soloAstra) + "\n\n"));

            doc.Close();
        }

        Console.WriteLine($"\n✅ Reporte PDF generado en: {Path.GetFullPath(ruta)}");
    }
}
