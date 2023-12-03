<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEmployeeMaster.aspx.cs" Inherits="Asp.net.frmEmployeeMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
   <script type="text/javascript">
       function CalculateSalary()
       {
         //  var grossal = document.getElementById("MainContent_txtgrosal");
         //  document.getElementById("MainContent_txtnetsal").value = grossal - deduction;

           var grossal = document.getElementById("MainContent_txtgrosal").value;
           var deduction = document.getElementById("MainContent_txtdeduct").value;
           document.getElementById("MainContent_txtnetsal").value = grossal - deduction;
       }

       function ClearControls()
       {
          /* document.getElementById("MainContent_txtempid").value = "";
           document.getElementById("MainContent_txtempname").value = "";
           document.getElementById("MainContent_ddesignation").value = "";
           document.getElementById("MainContent_txtgrosal").value = "";
           document.getElementById("MainContent_txtdeduct").value = "";
           document.getElementById("MainContent_txtnetsal").value = "";
           document.getElementById("MainContent_chckisactive").checked = false;*/

           
           var ctrls = document.getElementsByTagName('input');
           for (var i = 0; i < ctrls.length; i++)
           {
               if (ctrls[i].id.indexOf('MainContent') >=0 && ctrls[i].type == 'text')
                   ctrls[i].value = ' ';
               else if (ctrls[i].id.indexOf('MainContent') >=0 && ctrls[i].type == 'checkbox')
                   ctrls[i].checked = false;
              
           }

           return false;
       }

       function validateControls()
       {
           var returnflag = true; // <a href="Scripts/">Scripts/</a>
           if (document.getElementById("MainContent_txtempid").value =='')
           {
               alert("Please enter employee ID");
               document.getElementById("MainContent_txtempid").focus();
               returnflag = false;
           }
           else if (document.getElementById("MainContent_txtempname").value == '') {
               alert("Please enter employee name");
               document.getElementById("MainContent_txtempname").focus();
               returnflag = false;
           } 
           else if (document.getElementById("MainContent_ddesignation").value == '') {
               alert("Please enter employee designation");
               document.getElementById("MainContent_ddesignation").focus();
               returnflag = false;
           } 
           else if (document.getElementById("MainContent_txtgrosal").value == '') {
               alert("Please enter employee gross salary");
               document.getElementById("MainContent_txtgrosal").focus();
               returnflag = false;
           } 
           else if (document.getElementById("MainContent_txtdeduct").value == '') {
               alert("Please enter employee deduction");
               document.getElementById("MainContent_txtdeduct").focus();
               returnflag = false;
           } 
           else if (document.getElementById("MainContent_txtnetsal").value == '') {
               alert("Please enter employee netsalary");
               document.getElementById("MainContent_txtnetsal").focus();
               returnflag = false;
           } 
         /*  if (returnflag) {
               confirm('Do u want to save ');
           }
           else {
               Response.Write("record not save");
           }*/
     
       }
       function validateFields(ctrls, datatype, e)
       {
           debugger;
           var returnflag = true;
           if (datatype == 'int') {
               var nums = '0123456789\b';
               if (nums.indexOf(e.key.toString()) == -1)
                   returnflag = false;
           }
           else if (datatype == 'string') {
               var nums = 'abcdefghijklmnopqrstuvwxyz .@/b';
               if (nums.indexOf(e.key.toString().toLowerCase()) == -1)
                  returnflag =false;

               if (ctrls.value.split(' ').length >= 3 && e.key == ' ')
                   returnflag= false;
           }
           else if (datatype == 'double')
           {
               var nums = '0123456789\b.';
               if (nums.indexOf(e.key.toString()) == -1)
                   returnflag = false;
               if (ctrls.value.indexOf('.') >= 0 && e.key == '.')
                   returnflag = false;
           }
           return returnflag;


       }

       function SetColors(Row, Color)
       {
           debugger;
           Row.style.backgroundColor = Color;
       }
      function ShowRecords(Row)
       {
           debugger;
           document.getElementById('MainContent_txtempid').value = Row.children[0].innerHTML;
           document.getElementById('MainContent_txtempname').value = Row.children[1].innerHTML;
           document.getElementById('MainContent_ddesignation').value = Row.children[2].innerHTML;
           document.getElementById('MainContent_txtgrosal').value = Row.children[3].innerHTML;
           document.getElementById('MainContent_txtdeduct').value = Row.children[4].innerHTML;
           document.getElementById('MainContent_txtnetsal').value = Row.children[5].innerHTML;
           if (Row.children[6].innerHTML == 'Y')
               document.getElementById('MainContent_chckisactive').checked = true;
           else
               document.getElementById('MainContent_chckisactive').checked = false;
       }

   </script>

    Employee Master Entry  
    <table border="1" style="width:100%">
<tr>
    <th> EmployeeID</th>
    <td> 
        <asp:TextBox ID="txtempid" runat="server" OnTextChanged="txtempid_TextChanged" onkeypress="return validateFields(this,'int',event);" AutoPostBack="True"></asp:TextBox>
    </td>
 </tr>

 <tr>
    <th> EmployeeName</th>
    <td> 
        <asp:TextBox ID="txtempname" onkeypress="return validateFields(this,'string',event);" runat="server"></asp:TextBox>
    </td>
   </tr>
 
        <tr>
    <th> Designation</th>
    <td> 
       <asp:DropDownList ID="ddesignation" runat="server">
           <asp:ListItem Value="HR">HR </asp:ListItem>
           <asp:ListItem Value="developer">developer </asp:ListItem>
           <asp:ListItem Value="analyst">analyst</asp:ListItem>
           <asp:ListItem Value="tester">tester</asp:ListItem>
           <asp:ListItem Value="lecture">lecture</asp:ListItem>
           <asp:ListItem Value="trainer">trainer</asp:ListItem>
        </asp:DropDownList>
        <asp:HiddenField ID="hdnfnd" runat="server" Value="false" />
    </td>
</tr>
      <tr>
    <th> GrossSalary</th>
    <td> 
        <asp:TextBox ID="txtgrosal" onkeypress="return validateFields(this,'double',event);" runat="server" ></asp:TextBox>
    </td>
</tr>   
        
 <tr>
    <th> Deduction</th>
    <td> 
        <asp:TextBox ID="txtdeduct" runat="server" onblur="CalculateSalary();"  onkeypress="return validateFields(this,'double',event);" OnTextChanged="txtdeduct_TextChanged"></asp:TextBox>
    </td>
</tr>
<tr>
    <th> NetSalary</th>
    <td> 
        <asp:TextBox ID="txtnetsal" runat="server"></asp:TextBox>
    </td>
</tr>
 <tr>
    <th> IsActive</th>
 <td> 
     <asp:CheckBox ID="chckisactive" runat="server" />
</td> 
</tr>
        

 <tr>
   <th> &nbsp</th>
    <td> 
        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClientClick="return validateControls();" OnClick="btnSave_Click" /> &nbsp
        <asp:Button ID="btnCancel" runat="server" OnClientClick="return ClearControls();" Text="CANCEL" OnClick="btnCancel_Click" /> &nbsp
        <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClientClick="return confirm('Do u want to delete');" OnClick="btnDelete_Click" /> &nbsp
    </td>
</tr>
        <tr>
            <td colspan="2">
            <asp:GridView ID="grddata" runat="server" OnRowCreated="grddata_RowCreated" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
