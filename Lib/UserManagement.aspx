<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Lib.UserManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdUserList" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label ID="grdlblUserID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblFullName" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <asp:Label ID="grdlblDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mobile Number">
                        <ItemTemplate>
                            <asp:Label ID="grdlblMobileNumber" runat="server" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="grdlblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="grdlblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label ID="grdlblPassword" runat="server" Text='<%#Eval("Password") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Edit</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Delete</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
