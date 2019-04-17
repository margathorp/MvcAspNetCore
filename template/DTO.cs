using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<%
    var inc     =  Includes.split(",");
    var field   =  Fields.split("|");   
%>
namespace <%=Projeto%>.Models.ClassesDTO
{
    public class <%=ObjContext%>DTO : <%=ObjContext%>
    {
        public IQuerable< <%=ObjContext%> > Get<%=ObjContext%>()
        {
            return db.<%=ObjContext%>
        <% for(var i = 0; i < inc.length; i++){%>
            .Include(" <%=inc[i]%> ")<%}%>
            .Select(q => new <%=ObjContext%>DTO()
            {<% for(var i = 0; i < field.length; i++){var f = field[i].split(",")[0];%>
                <%=f%> = q.<%=f%>,<%}%>
            }).AsQueryable();
            
        }
    }
}