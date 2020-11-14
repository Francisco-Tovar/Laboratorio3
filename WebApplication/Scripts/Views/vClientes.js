
function vClientes() {

	this.tblClientesId = 'tblClientes';
	this.service = 'cliente';
	this.ctrlActions = new ControlActions();
	this.columns = "Id,Nombre,Apellido,DOB,Edad,ECivil,Sexo";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblClientesId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblClientesId, true);
	}

	this.Create = function () {
		var clienteData = {};
		clienteData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, clienteData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var clienteData = {};
		clienteData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, clienteData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var clienteData = {};
		clienteData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, clienteData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcliente = new vClientes();
	vcliente.RetrieveAll();

});

