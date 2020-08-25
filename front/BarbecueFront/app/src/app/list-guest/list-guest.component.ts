import { Component, OnInit } from '@angular/core';
import {ParticipantService} from '../services/participant-service'
import {Participant} from '../models/participant'

@Component({
  selector: 'app-list-guest',
  templateUrl: './list-guest.component.html',
  styleUrls: ['./list-guest.component.css'],
  providers: [ParticipantService]
})
export class ListGuestComponent implements OnInit {

  public guests : Array< Participant>


  public sizeGuest : number

  guestPagination : any = {
    itemsPerPage: 10,
    currentPage: 1,
    totalItems: this.guests
  };


  public maxSize: number = 1000
  public directionLinks: boolean = true;
  public autoHide: boolean = false;
  public responsive: boolean = true;
  public labels: any = {
      previousLabel: 'Anterior',
      nextLabel: 'Próximo',
  };

  constructor(private guestService : ParticipantService) { }

  ngOnInit(): void {
    this.listGuest()  
  }

  public async listGuest(){
    try{
      let response = await this.guestService.getGuest()
      this.guests = response
      this.sizeGuest = this.guests.length
   
      this.guests.forEach((element)=>{
        if(!element.goingToDrink){
          element.drinkPrice = 0
        }
      })
    }catch{
      console.log('Erro na Comunicação com o Servidor');
    }
  }

  public onPageChange(event){
    this.guestPagination.currentPage = event;
  }
}
