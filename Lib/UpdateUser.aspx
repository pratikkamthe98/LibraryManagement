<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Lib.UpdateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>

                <table>

                    <tr>
                        <td>Full Name</td>
                        <td>
                            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Date of Birth</td>
                        <td>
                            <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Mobile Number</td>
                        <td>
                            <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Address</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>User Name</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
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
        </div>
    </form>
</body>
</html>
