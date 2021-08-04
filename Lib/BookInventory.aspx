<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="Lib.BookInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblUserID" runat="server" Text="User ID"></asp:Label>
            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="lblBookID" runat="server" Text="Book ID"></asp:Label>
            <asp:TextBox ID="txtBookID" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp
            <asp:Button ID="btnGetBookDetails" runat="server" Text="Get" OnClick="GetDetails_Click" />
            <br />
            <br />

            <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server" ReadOnly="true"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="lblBookName" runat="server" Text="Book Name"></asp:Label>
            <asp:TextBox ID="txtBookName" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date"></asp:Label>
            <asp:TextBox ID="txtIssueDate" runat="server" TextMode="Date"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="lblReturnDate" runat="server" Text="Return Date"></asp:Label>
            <asp:TextBox ID="txtReturnDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnIssueBook" runat="server" Text="Issue Book" OnClick="IssueBook_Click" />&nbsp&nbsp&nbsp
           
            <br />
            <br />
            <asp:GridView ID="grdIssuedBookList" runat="server" AutoGenerateColumns="False" DataKeyNames="IssuedBookID" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>

                            <asp:Label ID="grdlblIssueID" runat="server" Text='<%#Eval("IssuedBookID") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label ID="grdlblUserID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblFullName" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Book ID">
                        <ItemTemplate>
                            <asp:Label ID="grdlblBookID" runat="server" Text='<%#Eval("BookID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Book Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblBookName" runat="server" Text='<%#Eval("BookName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Issue Date">
                        <ItemTemplate>
                            <asp:Label ID="grdlblIssueDate" runat="server" Text='<%#Eval("IssueDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Return Date">
                        <ItemTemplate>
                            <asp:Label ID="grdlblReturnDate" runat="server" Text='<%#Eval("ReturnDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnReturn" runat="server" CommandName="Return" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Delete</asp:LinkButton>


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
