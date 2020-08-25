export class Participant{
    public participantId : number
    public canceled : boolean
    public drinkPrice : number
    public foodPrice : number 
    constructor(
        public nameParticipant : string,
        public goingToEat : boolean,
        public goingToDrink : boolean,
        public isGuest : boolean,
        ){}

}