export class ConsultaFiltro {

    codigoProductoFinanciero: number;
    tipoMonedaId: string;
    montoMaximoAceptable: string;
    plazoMaximoMes: string;
    ingresoPermitido: string;
    departamentoId: string;
    tipoInstitucionId: string;
    montoMaximoDeposito: string;
    plazoMaximoDia: string;

    public ConsultaFiltro(codigo: number) {
        this.codigoProductoFinanciero = codigo;
    }

    public setFiltroDeposito(codigo: number, idTipoMonda: string, montoMaximoDeposito: string,
                             plazoMaximoDia: string, idDepartamento: string, idTipoInstitucion: string) {
            this.codigoProductoFinanciero = codigo;
            this.tipoMonedaId = idTipoMonda;
            this.montoMaximoDeposito = montoMaximoDeposito;
            this.plazoMaximoDia = plazoMaximoDia;
            this.departamentoId = idDepartamento;
            this.tipoInstitucionId = idTipoInstitucion;
    }
    public setFiltroPrestamo(codigo: number, idTipoMoneda: string, montoMaximoAceptable: string,
                             plazoMaximoMes: string, idDepartamento: string, idTipoInstitucion: string,
                             ingresoPermitido: string) {
            this.codigoProductoFinanciero = codigo;
            this.tipoMonedaId = idTipoMoneda;
            this.montoMaximoAceptable = montoMaximoAceptable;
            this.plazoMaximoMes = plazoMaximoMes;
            this.departamentoId = idDepartamento;
            this.tipoInstitucionId = idTipoInstitucion;
            this.ingresoPermitido = ingresoPermitido;
    }
}
