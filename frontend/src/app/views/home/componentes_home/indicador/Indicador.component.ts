import {
  ConteudosService
} from '../../../../services/service_conteudos/conteudos.service';

import {
  Component,
  EventEmitter,
  Output
} from '@angular/core';
import {
  Router
} from '@angular/router';
import * as bootstrap from 'bootstrap';

import Chart from 'chart.js/auto'

@Component({
  selector: 'app-materiais_digitais',
  templateUrl: './indicador.component.html',
  styleUrls: [],
})
export class NewIndicadorComponent {
  chart: any;
  regiao ? : any;
  conteudos: any;
  returnInd ? : any;
  titulo ? : any;
  anos ? : any;
  item: any;
  cont ? : any;
  codigo : any;
  i: any = 8;

  constructor(private service: ConteudosService, private router: Router) {

  }
  ngOnInit() {

    $("#vermenos").hide();

      this.service.getObjetivos().subscribe(res => {
        console.log(res);
        this.limiteConteudo(res);
      });
  }
  createChart(result: any[]) {
    const data = result.map((item: any) => item.consumo);
    const anos = result.map((item: any) => item.ano);
    const regiao = result[0].regiao;

    this.destroyChart();

    this.chart = new Chart('canvas', {
      type: 'bar',
      data: {
        labels: anos,
        datasets: [
          {
            label: regiao,
            data: data,
            backgroundColor: 'green'
          }
        ]
      },
      options: {

      }
    });
  }
  ngDoCheck() {

    if (this.i >= this.cont.length) {
      $("#vermais").hide();
      $("#vermenos").show();
    } else {
      $("#vermenos").hide();
      $("#vermais").show();
    }
  }

  destroyChart() {
    if (this.chart) {
      this.chart.destroy();
    }
  }

  changeComponente() {
    var regiaoSelect = $("#selectRegiao").val();

    this.service.getIndicadorByRegiao(regiaoSelect, this.codigo).subscribe(res => {
      this.cont = res;
      console.log
      this.createChart(res);
    });

  }



  VerMais() {
    this.i = this.i + 8;
    this.conteudos = this.cont.slice(0, this.i);
    if (this.i >= this.cont.length) {
      $("#vermais").hide();
      $("#vermenos").show();
    }
  }
  VerMenos() {
    this.conteudos = this.cont.slice(0, 8);
    $("#vermenos").hide();
    $("#vermais").show();
    this.i = 8;
  }

  openModalIndicador(currentId: any, descricao: any) {
    $("#tabela").hide();
    $("#grafico").hide();
    this.titulo = descricao;
    this.codigo = currentId;
     this.service.getIndicadorById(currentId).subscribe(res => {
      console.log(res)
      const uniqueAno = new Set();
      const uniqueRegiao = new Set();
      res.filter((item: { ano: number}) => {
        if (!uniqueAno.has(item.ano)) {
          uniqueAno.add(item.ano);
        }
      });
      this.anos = uniqueAno;
      res.filter((item: { regiao: string}) => {
        if (!uniqueRegiao.has(item.regiao)) {
          uniqueRegiao.add(item.regiao);
        }
      });
      this.regiao = uniqueRegiao;

      this.returnInd = res;
});



    $('#modal_conteudo').modal("show");
  }


  obterConsumo(regiao: string, ano: number): string {
    const dado = this.returnInd.find((item: any) => item.regiao === regiao && item.ano === ano);
    return dado ? dado.consumo.toFixed(1) : '';
  }
  dadosgrafico(){
    $("#tabela").hide();
    $("#grafico").show();
  }

  dadostabela(){
    $("#grafico").hide();
    $("#tabela").show();

  }
  limiteConteudo(res: any) {
    var largura = document.body.clientWidth;
    if (largura < 500) {
      this.cont = res;
      this.conteudos = res.slice(0, 2);
    } else {
      if (res.length <= 8) {
        this.cont = res;
        this.conteudos = res;
      } else {
        this.cont = res;
        this.conteudos = res.slice(0, 8);
      }
    }
  }
}
