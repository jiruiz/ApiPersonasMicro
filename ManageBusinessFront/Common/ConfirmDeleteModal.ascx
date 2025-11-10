<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="ConfirmDeleteModal.ascx.cs"
    Inherits="ManageBusinessFront.Common.ConfirmDeleteModal" %>

<asp:HiddenField ID="hfObjectId" runat="server" />

<div class="modal fade" id="confirmModal" tabindex="-1" role="dialog" aria-labelledby="confirmModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Confirmar eliminación</h4>
      </div>
      <div class="modal-body">
        ¿Estás seguro de que deseas eliminar este elemento?
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnConfirmDelete" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnConfirmDelete_Click" />
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
      </div>
    </div>
  </div>
</div>
