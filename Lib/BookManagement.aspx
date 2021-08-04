<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookManagement.aspx.cs" Inherits="Lib.BookManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdBookList" runat="server" AutoGenerateColumns="False" DataKeyNames="BookID" OnRowCommand="GridView1_RowCommand">

                <Columns>

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

                    <asp:TemplateField HeaderText="Author Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblAuthorName" runat="server" Text='<%#Eval("AuthorName") %>'></asp:Label>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Language">
                        <ItemTemplate>
                            <asp:Label ID="grdlblLanguage" runat="server" Text='<%#Eval("Language") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Genre">
                        <ItemTemplate>
                            <asp:Label ID="grdlblGenre" runat="server" Text='<%#Eval("Genre") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Publisher Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblPublisherName" runat="server" Text='<%#Eval("PublisherName") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Publish Date">
                        <ItemTemplate>
                            <asp:Label ID="grdlblPublishDate" runat="server" Text='<%#Eval("PublishDate") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Edition">
                        <ItemTemplate>
                            <asp:Label ID="grdlblBookEdition" runat="server" Text='<%#Eval("BookEdition") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Description">
                        <ItemTemplate>

                            <asp:Label ID="grdlblBookDescription" runat="server" Text='<%#Eval("BookDescription") %>'></asp:Label>
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
