import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms'
import {ParticipantPostRequest} from '../models/ParticipantPostRequest'
import {Participant} from '../models/participant'
import {ParticipantService} from '../services/participant-service'


@Component({
  selector: 'app-create-participant',
  templateUrl: './create-participant.component.html',
  styleUrls: ['./create-participant.component.css'],
  providers: [ParticipantService]
})
export class CreateParticipantComponent implements OnInit {


  public createParticipantForm : FormGroup = new FormGroup({
    "nameParticipant" : new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(40)]),
    "goingToDrink" : new FormControl(null),
    "nameGuest" : new FormControl(null, [ Validators.minLength(3), Validators.maxLength(40)]),
    "guestGoingDrink" : new FormControl(null),
    "goGuest" : new FormControl(null)
  })
 

  public disabledGuest : boolean = true

  constructor(private participantsService : ParticipantService) { }

  ngOnInit(): void {
  }

  public onChange($event){
    if(this.disabledGuest){
      this.disabledGuest = false
    }else{
      this.disabledGuest = true
      this.createParticipantForm.get('nameGuest').reset()
    }
   }

   public async createParticipant(){
     if(this.createParticipantForm.status === "INVALID"){
       this.createParticipantForm.get('nameParticipant').markAsTouched()

     }else{
      let objParticipant : Participant = new Participant(
      this.createParticipantForm.value.nameParticipant, true, this.createParticipantForm.value.goingToDrink ? true : false, false)

       let objGuestParticipant : Participant
        if(this.disabledGuest != true){
          objGuestParticipant = new Participant(
          this.createParticipantForm.value.nameGuest, true, this.createParticipantForm.value.guestGoingDrink ? true : false, true)
        }
       let response : ParticipantPostRequest = new ParticipantPostRequest(objParticipant, objGuestParticipant)  
       await this.participantsService.postParticipants(response);
       this.refreshPage()
     }
   }

  public refreshPage() {
    location.reload()
  }
  
}
