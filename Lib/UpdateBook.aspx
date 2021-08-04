<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="Lib.UpdateBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>

                <tr>
                    <td>Book Name</td>
                    <td>
                        <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Author Name</td>
                    <td>
                        <asp:TextBox ID="txtAuthorName" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Language</td>
                    <td>
                        <asp:DropDownList ID="ddlLanguageList" runat="server">
                            <asp:ListItem Text="English" Value="English" />
                            <asp:ListItem Text="French" Value="French" />
                            <asp:ListItem Text="German" Value="German" />
                        </asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <td>Genre</td>
                    <td>
                        <asp:DropDownList ID="ddlGenreList" runat="server">
                            <asp:ListItem Text="Action" Value="Action" />
                            <asp:ListItem Text="Adventure" Value="Adventure" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Publisher Name</td>
                    <td>
                        <asp:TextBox ID="txtPublisherName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Publish Date</td>
                    <td>
                        <asp:TextBox ID="txtPublishDate" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Book Edition</td>
                    <td>
                        <asp:TextBox ID="txtBookEdition" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Book Description</td>
                    <td>
                        <asp:TextBox ID="txtBookDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td style="align-content: center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                    <td style="align-content: center">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
