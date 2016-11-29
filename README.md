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
<h3 style="font-weight:normal;">Follow chsakell's Blog</h3>
<table id="gradient-style" style="box-shadow:3px -2px 10px #1F394C;font-size:12px;margin:15px;width:290px;text-align:left;border-collapse:collapse;" summary="">
<thead>
<tr>
<th style="width:130px;font-size:13px;font-weight:bold;padding:8px;background:#1F1F1F repeat-x;border-top:2px solid #d3ddff;border-bottom:1px solid #fff;color:#E0E0E0;" align="center" scope="col">Facebook</th>
<th style="font-size:13px;font-weight:bold;padding:8px;background:#1F1F1F repeat-x;border-top:2px solid #d3ddff;border-bottom:1px solid #fff;color:#E0E0E0;" align="center" scope="col">Twitter</th>
</tr>
</thead>
<tfoot>
<tr>
<td colspan="4" style="text-align:center;">Microsoft Web Application Development</td>
</tr>
</tfoot>
<tbody>
<tr>
<td style="padding:8px;border-bottom:1px solid #fff;color:#FFA500;border-top:1px solid #fff;background:#1F394C repeat-x;">
<a href="https://www.facebook.com/chsakells.blog" target="_blank"><img src="https://chsakell.files.wordpress.com/2015/08/facebook.png?w=120&amp;h=120&amp;crop=1" alt="facebook" width="120" height="120" class="alignnone size-opti-archive wp-image-3578"></a>
</td>
<td style="padding:8px;border-bottom:1px solid #fff;color:#FFA500;border-top:1px solid #fff;background:#1F394C repeat-x;">
<a href="https://twitter.com/chsakellsBlog" target="_blank"><img src="https://chsakell.files.wordpress.com/2015/08/twitter-small.png?w=120&amp;h=120&amp;crop=1" alt="twitter-small" width="120" height="120" class="alignnone size-opti-archive wp-image-3583"></a>
</td>
</tr>
</tbody>
</table>
<h3>License</h3>
Code released under the <a href="https://github.com/chsakell/wcf-dot-net-core/blob/master/licence" target="_blank"> MIT license</a>.
