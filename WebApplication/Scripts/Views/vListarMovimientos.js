
function vListarMovimientos() {

	this.tblCuentasId = 'tblCuentas';
	this.service = 'movimiento';
	this.ctrlActions = new ControlActions();
	this.columns = "IdMovimiento,IdCuenta,Fecha,Tipo,Monto";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCuentasId, true);
	}	
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcuenta = new vListarMovimientos();	
	vcuenta.RetrieveAll();
});

