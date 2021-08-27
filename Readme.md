<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128611149/10.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1604)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/GetTextMethodsExample/Form1.cs) (VB: [Form1.vb](./VB/GetTextMethodsExample/Form1.vb))
<!-- default file list end -->
# How to save the text of a document range in different formats


<p>This example illustrates API methods used to get the text of the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditAPINativeDocumentRangetopic">document range</a> in different formats - RTF, HTML, MHT, DOCX.<br />
Although the preferable technique to save the document in different formats is the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraRichEditAPINativeDocument_SaveDocumenttopic">SaveDocument</a> and the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraRichEditRichEditControl_SaveDocumentAstopic">SaveDocumentAs</a> methods, several methods allow obtaining text of the specified range in different formats. Current example provides code snippets which use these methods. Note the implementation of the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditServicesIUriProvidertopic">IUriProvider</a> interface required for HTML export.</p>


<h3>Description</h3>

<p>When implementing the DevExpress.XtraRichEdit.Services.IUriProvider interface, in the CreateImageUri method use the DevExpress.XtraRichEdit.Utils.RichEditImage class object as an argument instead of the System.Drawing.Image.</p>

<br/>


