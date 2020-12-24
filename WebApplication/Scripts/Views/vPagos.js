
function vPagos() {

	this.tblCuentasId = 'tblPagos';
	this.service = 'pago';
	this.ctrlActions = new ControlActions();
	this.columns = "IdCredito,IdCliente,Monto,Tasa,Nombre,Cuota,Fecha,Estado,Saldo";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable("credito", this.tblCuentasId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable("credito", this.tblCuentasId, true);
	}

	this.Create = function () {
		var cuentaData = {};
		cuentaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, cuentaData);
		//Refresca la tabla
		this.ReloadTable();
	}
	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcuenta = new vPagos();	
	vcuenta.RetrieveAll();
});

