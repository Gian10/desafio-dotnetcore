import { Component, OnInit } from '@angular/core';
import {TotalCollectedSpendService} from '../services/totalCollectedSpend-service'

@Component({
  selector: 'app-view-main',
  templateUrl: './view-main.component.html',
  styleUrls: ['./view-main.component.css'],
  providers: [TotalCollectedSpendService]
})
export class ViewMainComponent implements OnInit {

  public totalSpendFood : number
  public totalSpendDrink : number
  public totalCollect : number

  constructor(private totalSpendCollectService : TotalCollectedSpendService) { }

  async ngOnInit(): Promise<void> {
    try{
      this.totalCollect = await this.totalSpendCollectService.getTotalCollected()
      this.totalSpendDrink = await this.totalSpendCollectService.getTotalSpendDrink()
      this.totalSpendFood = await this.totalSpendCollectService.getTotalSpendFood()
    }catch{
      console.log('Erro na Comunicação com o Servidor');
    }
  }

}
