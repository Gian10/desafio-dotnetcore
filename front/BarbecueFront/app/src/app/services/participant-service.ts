import {Participant} from '../models/participant'
import {environment} from '../../environments/environment'
import {ParticipantPostRequest} from '../models/ParticipantPostRequest'

import {HttpClient, HttpHeaders} from '@angular/common/http'

import {Injectable} from '@angular/core'

const httpOption ={
    headers : new HttpHeaders({
        "Content-Type" : "application/json"
    })
}

@Injectable()
export class ParticipantService{

    constructor(private http : HttpClient){}

    getParticipant() : Promise<Array<Participant>>{
        let response = this.http.get<Array<Participant>>(`${environment.api}/Participants`, httpOption).toPromise()
        return response 
    }

    canceledParticipant(id : number) : Promise<Participant>{
        let response = this.http.delete<Participant>(`${environment.api}/Participants/${id}`, httpOption).toPromise()
        return response
    }

    getGuest(): Promise<Array<Participant>>{
        let response = this.http.get<Array<Participant>>(`${environment.api}/Participants/guest`, httpOption).toPromise()
        return response
    }

    postParticipants(participants : ParticipantPostRequest): Promise<ParticipantPostRequest>{
        let response = this.http.post<ParticipantPostRequest>(`${environment.api}Participants`, participants, httpOption).toPromise()
        return response  
    }
}