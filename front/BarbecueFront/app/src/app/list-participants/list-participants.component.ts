import { Component, OnInit } from '@angular/core';
import {Participant} from '../models/participant'
import {ParticipantService} from '../services/participant-service'

@Component({
  selector: 'app-list-participants',
  templateUrl: './list-participants.component.html',
  styleUrls: ['./list-participants.component.css'],
  providers: [ParticipantService]
})
export class ListParticipantsComponent implements OnInit {

  public participants : Array<Participant>

  public sizeParticipants : number

  // objeto de paginação
  participantPagination : any = {
    itemsPerPage: 10,
    currentPage: 1,
    totalItems: this.participants
  };


// montar a personalização da paginação
  public maxSize: number = 1000
  public directionLinks: boolean = true;
  public autoHide: boolean = false;
  public responsive: boolean = true;
  public labels: any = {
      previousLabel: 'Anterior',
      nextLabel: 'Próximo',
  };
  

  constructor(private participantService : ParticipantService) { }

  ngOnInit(): void {
    this.listParticipants()
    
  }

  public async listParticipants(){
    try{
      let response = await this.participantService.getParticipant()
      this.participants = response
      this.sizeParticipants = this.participants.length

      this.participants.forEach(element => {
        if(element.goingToDrink == false){
          element.drinkPrice = 0        
        }
      }); 
    }catch{
      console.log('Erro na Comunicação com o Servidor'); 
    }
  }

  public async deleteParticipant(id : number){
    await this.participantService.canceledParticipant(id)
    this.refreshPage()
  }
  
  public refreshPage() {
    location.reload()
  }

  // método de evento ao clique da pagina
  public onPageChange(event){
    this.participantPagination.currentPage = event;
  }
}
