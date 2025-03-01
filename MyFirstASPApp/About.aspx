<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MyFirstASPApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>
        <!-- GridView to display, edit, and delete student records -->
        <asp:GridView ID="IdGridVIew" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            OnRowEditing="IdGridVIew_RowEditing" 
            OnRowCancelingEdit="IdGridVIew_RowCancelingEdit" 
            OnRowUpdating="IdGridVIew_RowUpdating" 
            OnRowDeleting="IdGridVIew_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Stream" HeaderText="Stream" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        
        <br />
        
        <!-- Insert new student panel -->
        <asp:Panel ID="InsertPanel" runat="server">
            <h4>Insert New Student</h4>
            <asp:TextBox ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="txtDOB" runat="server" placeholder="yyyy-MM-dd"></asp:TextBox>
            <asp:TextBox ID="txtStream" runat="server" placeholder="Stream"></asp:TextBox>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        </asp:Panel>
        
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </main>
</asp:Content>
