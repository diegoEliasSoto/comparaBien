import {Component, OnInit} from '@angular/core';
import {ProductoFinanciero} from '../../../../models/producto-financiero';
import {ProductoServicioService} from '../../../../services/producto-servicio.service';
import {ConsultaFiltro} from '../../../../models/consultaFiltro';
import {FormGroup, FormBuilder} from '@angular/forms';
import {DepartamentoService} from '../../../../services/departamento.service';
import {ActivatedRoute} from '@angular/router';
import {CODIGO_PRESTAMO} from '../../../../utils/constantes';

@Component({
  selector: 'app-filtro-prestamo',
  templateUrl: './filtro-prestamo.component.html',
  styleUrls: ['./filtro-prestamo.component.css']
})
export class FiltroPrestamoComponent implements OnInit {

  departamentos: { label: string, value: any }[];
  filtro: ConsultaFiltro;
  form: FormGroup;
  dataProducto: ProductoFinanciero[];
  estado = false;

  constructor(private readonly servicioProducto: ProductoServicioService,
              private readonly departamentoService: DepartamentoService, private readonly fb: FormBuilder,
              public readonly route: ActivatedRoute) {
    this.createForm();
    this.cargarFormulario();
  }

  ngOnInit(): void {
    this.servicioProducto.listaCambios.subscribe(data => {
      this.dataProducto = data;
    });
    this.listar();
    this.cargarDepartamento();
  }

  listar() {
    if (this.filtro != null) {
      this.servicioProducto.listar(this.filtro).subscribe(data => {
        console.log('data', data)
        this.dataProducto = data;
      });
      this.filtro.ConsultaFiltro(CODIGO_PRESTAMO);
    }
  }

  createForm() {
    this.form = this.fb.group({
      monto: [],
      plazo: [],
      ingreso: [],
      tipoMoneda: [],
      banco: [],
      departamento: []
    });
  }

  cargarDepartamento() {
    this.departamentoService.listar().subscribe(data => {
      this.departamentos = data;
    });
  }

  cargarFormulario() {
    if (this.filtro != null) {
      this.form.setValue({
        monto: this.filtro.montoMaximoAceptable,
        plazo: this.filtro.plazoMaximoMes,
        ingreso: this.filtro.ingresoPermitido,
        tipoMoneda: this.filtro.tipoMonedaId,
        banco: this.filtro.tipoInstitucionId,
        departamento: this.filtro.departamentoId
      });
    } else {
      this.form.setValue({
        monto: 1000,
        plazo: 6,
        ingreso: 500,
        tipoMoneda: '5',
        banco: '8',
        departamento: 1
      });
    }
  }

  activateAnimation() {
  }

  filtrar() {
    const filtro = new ConsultaFiltro();
    filtro.setFiltroPrestamo(CODIGO_PRESTAMO, this.form.value.tipoMoneda, this.form.value.monto,
      this.form.value.plazo, this.form.value.departamento, this.form.value.banco, this.form.value.ingreso);
    console.log(filtro);
    this.servicioProducto.listar(filtro).subscribe(data => {
      this.servicioProducto.listaCambios.next(data);
    });
  }

  cargarData(event: any) {
    this.filtro = event;
    console.log(this.filtro);
    this.cargarFormulario();
    this.listar();
  }

  ocultar(event: any) {
    this.estado = event;
  }

}
