import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

    public eventos: any = [];
    public eventosFiltrados: any = [];

    widthImg: number = 150;
    marginImg: number = 2;
    visibilityImg: boolean = false;
    private _filtroLista: string = '';

    public get filtroLista(): string {
      return this._filtroLista;
    }

    public set filtroLista(value: string){
      this._filtroLista = value;
      this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    }

    filtrarEventos(filtrarPor: string): any {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.eventos.filter(
        (evento: { tema: string; local: string}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      )
    }

//   [{
//     Tema: 'Angular 12',
//     Local: 'Belo Horizonte'
//   },{
//     Tema: '.NET 5',
//     Local: 'Natal'
//   },{
//     Tema: 'Angular e suas novidades',
//     Local: 'Salvador'
//   }
// ]
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  changeVisibility(){
    this.visibilityImg = !this.visibilityImg
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
      this.eventosFiltrados = this.eventos;},
      error => console.log(error)
    );
  }
}
