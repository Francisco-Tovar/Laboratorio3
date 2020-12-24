
function vListarPagos() {

	this.tblCuentasId = 'tblCuentas';
	this.service = 'pago';
	this.ctrlActions = new ControlActions();
	this.columns = "IdPago,IdCredito,Fecha,Operacion,Monto";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, true);
	}	
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcuenta = new vListarPagos();	
	vcuenta.RetrieveAll();
});

