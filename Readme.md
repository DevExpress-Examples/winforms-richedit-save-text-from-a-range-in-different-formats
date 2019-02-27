<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/GetTextMethodsExample/Form1.cs) (VB: [Form1.vb](./VB/GetTextMethodsExample/Form1.vb))
* [frmBrowser.cs](./CS/GetTextMethodsExample/frmBrowser.cs) (VB: [frmBrowser.vb](./VB/GetTextMethodsExample/frmBrowser.vb))
* [Program.cs](./CS/GetTextMethodsExample/Program.cs) (VB: [Program.vb](./VB/GetTextMethodsExample/Program.vb))
<!-- default file list end -->
# How to save the document range in different formats

This example illustrates API methods used to get the text of the [document range](https://docs.devexpress.com/WindowsForms/6979) in different formats - RTF, HTML, MHT, DOCX.

![screenshot](./images/screenshot.png)

API in this example:

* [Document.Selection](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.Document.Selection) property
* [SubDocument.GetMhtText](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.SubDocument.GetMhtText(DevExpress.XtraRichEdit.API.Native.DocumentRange)) method
* [SubDocument.GetHtmlText](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.SubDocument.GetHtmlText.overloads) method
* [SubDocument.GetOpenXmlBytes](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.SubDocument.GetOpenXmlBytes.overloads) method
* [SubDocument.GetRtfText](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.SubDocument.GetRtfText.overloads) method
* [SubDocument.GetWordMLText](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.SubDocument.GetWordMLText.overloads) method
* [RichEditControl.BeforeExport](https://docs.devexpress.com/WindowsForms/DevExpress.XtraRichEdit.RichEditControl.BeforeExport) event
* [HtmlDocumentExporterOptions](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions) class
* [IUriProvider](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.Services.IUriProvider) interface


**See also:**

* [Positions and Ranges](https://docs.devexpress.com/WindowsForms/6979)
* [Import and Export](https://docs.devexpress.com/WindowsForms/9333)

