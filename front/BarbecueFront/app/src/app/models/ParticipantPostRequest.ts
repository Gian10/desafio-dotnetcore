import {Participant} from '../models/participant'

export class ParticipantPostRequest{
    constructor( public emploee : Participant, public guest : Participant){}
}