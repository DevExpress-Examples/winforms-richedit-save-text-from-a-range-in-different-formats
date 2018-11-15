<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/GetTextMethodsExample/Form1.cs) (VB: [Form1.vb](./VB/GetTextMethodsExample/Form1.vb))
* [frmBrowser.cs](./CS/GetTextMethodsExample/frmBrowser.cs) (VB: [frmBrowser.vb](./VB/GetTextMethodsExample/frmBrowser.vb))
<!-- default file list end -->
# How to save the text of a document range in different formats


<p>This example illustrates API methods used to get the text of the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditAPINativeDocumentRangetopic">document range</a> in different formats - RTF, HTML, MHT, DOCX.<br />
Although the preferable technique to save the document in different formats is the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraRichEditAPINativeDocument_SaveDocumenttopic">SaveDocument</a> and the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraRichEditRichEditControl_SaveDocumentAstopic">SaveDocumentAs</a> methods, several methods allow obtaining text of the specified range in different formats. Current example provides code snippets which use these methods. Note the implementation of the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditServicesIUriProvidertopic">IUriProvider</a> interface required for HTML export.</p>

<br/>


