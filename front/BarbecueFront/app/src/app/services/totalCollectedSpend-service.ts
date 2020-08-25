import {Injectable} from '@angular/core'
import {HttpClient, HttpHeaders} from '@angular/common/http'
import {environment} from '../../environments/environment'

const httpOptions = {
    headers : new HttpHeaders({
        "Content-Type" : "application/json"
    })
}


@Injectable()
export class TotalCollectedSpendService{

    constructor(private http : HttpClient){}

    getTotalCollected(): Promise<number>{  
        let response = this.http.get<number>(`${environment.api}Participants/totalCollected`, httpOptions).toPromise()
        return response
    }

    getTotalSpendFood() : Promise<number>{
        let response = this.http.get<number>(`${environment.api}Participants/totalSpendFood`, httpOptions).toPromise()
        return response
    }

    getTotalSpendDrink() : Promise<number>{
        let response = this.http.get<number>(`${environment.api}Participants/totalSpendDrink`, httpOptions).toPromise()
        return response
    }

}