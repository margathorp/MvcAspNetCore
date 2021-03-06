using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
<%
    var fields = Fields.split("|");
    var nome = "";
    var tipo = "";
    var mask = "";
    var hidden = "";  
    var required = "" ;
    var requiredtxt = "";
%>
namespace <%=Projeto%>.Models.Context
{
    [ModelMetadataType(typeof(I<%=ObjContext%>Metadata))]
    public partial class <%=ObjContext%>:I<%=ObjContext%>Metadata{}
    public interface I<%=ObjContext%>Metadata
    {   <% for(var i = 0; i < fields.length; i++){ nome = fields[i].split(",")[0]; tipo = fields[i].split(",")[1]; mask = fields[i].split(",")[2];hidden = fields[i].split(",")[3];databasename = fields[i].split(",")[4];nometela = fields[i].split(",")[5];required = fields[i].split(",")[6];requiredtxt = fields[i].split(",")[7];%>
        <%if(required=="*"){%>[Required(ErrorMessage="<%=requiredtxt%>")] <%}%>
        [DisplayName("<%=nometela%><%=required%>")]        
        <%=tipo%> <%=databasename%> {get;set;}
        <%}%>
    }
}