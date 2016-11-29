# WCF Proxies in .NET Core
The solution self hosts a WCF Service <i>(two endpoints - BasicHttpBinding and NetTcpBinding)</i> to be consumed by the following two different types of .NET Core proxies
<ol>
<li>Proxies created using the <a href="https://marketplace.visualstudio.com/items?itemName=erikcai-MSFT.VisualStudioWCFConnectedService">Visual Studio WCF Connected Service</a> extension</li>
<li>Proxies created manually <i>(cross-platform library)</i></li>
</ol>
<h3>Instructions</h3>
<ol>
<li>Open the solution in VS 2015 as administrator</li>
<li>Build the solution to restore Nuget Packages</li>
<li>Make sure to restore .NET Core packages as well</li>
<li>Alter the connection string in <i>Self.Host/App.config</i> to point to your SQL Server. The database will be created automatically</li>
<li>Run the <b>Self.Host</b> project to host the WCF Service</li>
<li>Run the <b>Core.App</b> .NET Core app</li>
</ol>
<h3>.NET Core solution projects</h3>
<ul>
<li><a href="https://github.com/chsakell/wcf-dot-net-core/tree/master/Connected.Service">Connected.Service</a> is a .NET Core library that contains the WCF proxies created using the <a href="https://marketplace.visualstudio.com/items?itemName=erikcai-MSFT.VisualStudioWCFConnectedService">Visual Studio WCF Connected Service</a> extension</li>
<li><a href="https://github.com/chsakell/wcf-dot-net-core/tree/master/External.Lib">External.Lib</a> is a .NET Core library that contains the WCF proxies created manually</li>
<li><a href="https://github.com/chsakell/wcf-dot-net-core/tree/master/Core.App">Core.App</a> is a .NET Core MVC Web Application that references the previous projects in order to consume a WCF Service via HTTP and TCP</li>
</ul>
<h3>License</h3>
Code released under the <a href="https://github.com/chsakell/wcf-dot-net-core/blob/master/licence" target="_blank"> MIT license</a>.
