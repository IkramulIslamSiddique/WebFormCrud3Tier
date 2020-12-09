<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebForm.WebForm2" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html  
    xmlns="http://www.w3.org/1999/xhtml">  
    <head runat="server">  
        <title></title>  
    </head>  
    <body>  
        <form id="form1" runat="server">  
            <div>  
                <table>  
                    <tr>  
                        <td>  
                            <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>  
                        </td>  
                        <td>  
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                            <asp:Label ID="lblAge" runat="server" Text="Enter Age"></asp:Label>  
                        </td>  
                        <td>  
                            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                            <asp:Label ID="lblAddress" runat="server" Text="Enter Address"></asp:Label>  
                        </td>  
                        <td>  
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />  
                        </td>  
                    </tr>  
                    <tr>  
                        <td>  
                            <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="false"  
                                AllowPaging="true" PageSize="2"  
                                onrowcommand="gvDisplay_RowCommand" onrowdeleting="gvDisplay_RowDeleting"  
                                onselectedindexchanging="gvDisplay_SelectedIndexChanging"  
                                onpageindexchanging="gvDisplay_PageIndexChanging">  
                                <Columns>  
                                    <asp:BoundField DataField="Id" HeaderText="Id" />  
                                    <asp:BoundField DataField="Name" HeaderText="Name" />  
                                    <asp:BoundField DataField="Address" HeaderText="Address" />  
                                    <asp:BoundField DataField="Age" HeaderText="Age" />  
                                    <asp:CommandField ButtonType="Button" SelectText="Edit" ShowSelectButton="True" />  
                                    <asp:TemplateField>  
                                        <ItemTemplate>  
                                            <asp:Button runat="server" ID="btnDelete" OnClientClick="return confirm('Are you sure,you want to delete this record ?');" Text="Delete" CommandArgument='  
                                                <%# Eval("Id") %>' CommandName="Delete" />  
                                            </ItemTemplate>  
                                        </asp:TemplateField>  
                                    </Columns>  
                                </asp:GridView>  
                            </td>  
                        </tr>  
                    </table>  
                </div>  
            </form>  
        </body>  
    </html>  