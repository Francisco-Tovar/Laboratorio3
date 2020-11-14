
function vCreditos() {

	this.tblCreditosId = 'tblCreditos';
	this.service = 'credito';
	this.ctrlActions = new ControlActions();
	this.columns = "IdCredito,IdCliente,Monto,Tasa,Nombre,Cuota,Fecha,Estado,Saldo";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCreditosId, false); 		
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCreditosId, true);
	}

	this.Create = function () {
		var creditoData = {};
		creditoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, creditoData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var creditoData = {};
		creditoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, creditoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var creditoData = {};
		creditoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, creditoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcredito = new vCreditos();
	vcredito.RetrieveAll();

});

