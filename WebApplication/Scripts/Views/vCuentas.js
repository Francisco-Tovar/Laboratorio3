
function vCuentas() {

	this.tblCuentasId = 'tblCuentas';
	this.service = 'cuenta';
	this.ctrlActions = new ControlActions();
	this.columns = "IdCuenta,IdCliente,Tipo,Moneda,Saldo";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, true);
	}

	this.Create = function () {
		var cuentaData = {};
		cuentaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, cuentaData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var cuentaData = {};
		cuentaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, cuentaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var cuentaData = {};
		cuentaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, cuentaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcuenta = new vCuentas();
	vcuenta.RetrieveAll();

});

