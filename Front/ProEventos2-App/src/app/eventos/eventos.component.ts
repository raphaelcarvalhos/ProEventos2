import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

    public eventos: any;
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

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }
}
