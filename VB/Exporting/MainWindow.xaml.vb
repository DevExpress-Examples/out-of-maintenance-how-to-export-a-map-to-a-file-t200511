Imports System
Imports System.Windows
Imports DevExpress.XtraPrinting

Namespace Exporting
    Partial Public Class MainWindow
        Inherits Window

        Private Const filename As String = "exportedMap"

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim format As ExportFormat = CType(cbExportFormat.SelectedItem, ExportFormat)
            Dim filepath As String
            If format = ExportFormat.Image Then
                filepath = String.Format("{0}.jpg", filename)
            Else
                filepath = String.Format("{0}.{1}", filename, format)
            End If
            Dim isExported As Boolean = True
            Select Case format
                Case (ExportFormat.Htm)
                    mapControl.ExportToHtml(filepath)
                Case (ExportFormat.Image)
                    mapControl.ExportToImage(filepath)
                Case (ExportFormat.Mht)
                    mapControl.ExportToMht(filepath)
                Case (ExportFormat.Pdf)
                    mapControl.ExportToPdf(filepath)
                Case (ExportFormat.Rtf)
                    mapControl.ExportToRtf(filepath)
                Case (ExportFormat.Xls)
                    mapControl.ExportToXls(filepath)
                Case (ExportFormat.Xlsx)
                    mapControl.ExportToXlsx(filepath)
                Case (ExportFormat.Xps)
                    mapControl.ExportToXps(filepath)
                Case Else
                    isExported = False
            End Select
            If isExported Then
                MessageBox.Show(String.Format("Map exported successfully."))
            Else
                MessageBox.Show(String.Format("Map exporting does not support the {0} file format.", format))
            End If
        End Sub
    End Class
End Namespace
