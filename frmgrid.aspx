<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmgrid.aspx.cs" Inherits="Asp.net.frmgrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMPLOYEEMASTER FORM</title>
        
</head>
   
    
    
    <script type="text/javascript">

        function CalculateTotal(Row)
        {
            var grossal = Row.children[3].children[0].value;
            var deduction = grossal * 0.10
            Row.children[4].children[0].value = deduction;
            Row.children[5].children[0].value = grossal - deduction;
            VerticalTotal();
        }

       /* function VerticalTotal()
        {
            debugger;
            var grossal = 0;
            var deduction = 0;
            var netsal = 0;
            var grid = document.getElementById('grddata');

            for (int i = 1; i < grid.rows.length - 1; i++)
            {
                grossal += parseFloat(grid.rows[i].children[3].childern[0].value);
                deduction += parseFloat(grid.rows[i].children[4].childern[0].value);
                netsal += parseFloat(grid.rows[i].children[5].childern[0].value);
            }
            grid.rows[grid.rows.length - 1].children[3].innerHTML = grossal;
            grid.rows[grid.rows.length - 1].children[4].innerHTML = deduction;
            grid.rows[grid.rows.length - 1].children[5].innerHTML = netsal;
        }
        */

    </script>


<body>
    <h3>EMPLOYEE MASTER FORM</h3>
   
    <form id="form1" runat="server">
        
        <div>
            
            <asp:GridView ID="grddata" runat="server" AutoGenerateColumns="False" style="margin-left: 58px" Height="353px" OnRowCreated="grddata_RowCreated" Width="917px"
                ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None">
               
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               
                <Columns>
                    <asp:TemplateField HeaderText="EmployeeID">
                        <ItemTemplate>
                            <asp:TextBox ID="grd_txt_empid" runat="server" Text='<%# Eval("empid") %>'></asp:TextBox>
                             <asp:HiddenField ID="grd_hdn_empid" runat="server" Value='<%# Eval("empid") %>'></asp:HiddenField>
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                    <asp:TemplateField HeaderText="EmployeeName">
                        <ItemTemplate>
                            <asp:TextBox ID="grd_txt_empname" runat="server" Text='<%# Eval("empname") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Designation">
                     <ItemTemplate>
                         <asp:DropDownList ID="grd_cmbdesignation" runat="server" SelectedValue='<%# Eval("designation") %>'>
                             <asp:ListItem Value="HR">HR </asp:ListItem>
                             <asp:ListItem Value="developer">developer </asp:ListItem>
                             <asp:ListItem Value="analyst">analyst</asp:ListItem>
                             <asp:ListItem Value="tester">tester</asp:ListItem>
                             <asp:ListItem Value="lecture">lecture</asp:ListItem>
                             <asp:ListItem Value="trainer">trainer</asp:ListItem>
                         </asp:DropDownList>
                    </ItemTemplate>
                   </asp:TemplateField>
                   

                     <asp:TemplateField HeaderText="Grossal">
                     <ItemTemplate>
                      <asp:TextBox ID="grd_txt_grossal" runat="server" Text='<%# Eval("grosssal") %>'></asp:TextBox>
                      </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Deduction">
                    <ItemTemplate>
                   <asp:TextBox ID="grd_txt_deduct" runat="server" Text='<%# Eval("deductions") %>'></asp:TextBox>
               </ItemTemplate>
               </asp:TemplateField>

                    

                     <asp:TemplateField HeaderText="Netsal">
                     <ItemTemplate>
         <asp:TextBox ID="grd_txt_netsal" runat="server" Text='<%# Eval("netsal") %>'></asp:TextBox>
                </ItemTemplate>
             </asp:TemplateField>

                    <asp:TemplateField HeaderText="IsActive">
            <ItemTemplate>
                <asp:CheckBox ID="grd_chckisactive" runat="server" Checked='<%# Eval("isactive").ToString()=="Y"?true:false %>' />
           </ItemTemplate>
           </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:CheckBox ID="grd_chck_save" runat="server" />
           </ItemTemplate>
           </asp:TemplateField>
                </Columns>
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
                <asp:Button ID="btn_add_row" runat="server" Text="Add Row" OnClick="btn_add_row_Click" />
            &nbsp;
                <asp:Button runat="server" Text="Save" ID="btn_save" OnClick="btn_save_Click" />
              &nbsp;
                <asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" />
           
        </div>
    </form>
    <script type="text/javascript">
        VerticalTotal();
    </script>
</body>
</html>
