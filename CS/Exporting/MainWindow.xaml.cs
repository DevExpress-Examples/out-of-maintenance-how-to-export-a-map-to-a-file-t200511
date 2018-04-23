using System;
using System.Windows;
using DevExpress.XtraPrinting;

namespace Exporting {
    public partial class MainWindow : Window {
        const string filename = "exportedMap";
        
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ExportFormat format = (ExportFormat)cbExportFormat.SelectedItem;
            string filepath;
            if (format == ExportFormat.Image)
                filepath = String.Format("{0}.jpg", filename);
            else
                filepath = String.Format("{0}.{1}", filename, format);
            bool isExported = true;
            switch (format) { 
                case (ExportFormat.Htm):
                    mapControl.ExportToHtml(filepath);
                    break;
                case (ExportFormat.Image):
                    mapControl.ExportToImage(filepath);
                    break;
                case (ExportFormat.Mht): 
                    mapControl.ExportToMht(filepath);
                    break;
                case (ExportFormat.Pdf): 
                    mapControl.ExportToPdf(filepath);
                    break;
                case (ExportFormat.Rtf): 
                    mapControl.ExportToRtf(filepath);
                    break;
                case (ExportFormat.Xls): 
                    mapControl.ExportToXls(filepath);
                    break;
                case (ExportFormat.Xlsx): 
                    mapControl.ExportToXlsx(filepath);
                    break;
                case (ExportFormat.Xps): 
                    mapControl.ExportToXps(filepath);
                    break;
                default: 
                    isExported = false;
                    break;
            }
            if (isExported) 
                MessageBox.Show(String.Format("Map exported successfully."));
            else
                MessageBox.Show(String.Format("Map exporting does not support the {0} file format.", format)); 
        }
    }
}
