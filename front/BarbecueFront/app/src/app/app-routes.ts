import {Routes} from '@angular/router'

import {ListParticipantsComponent} from './list-participants/list-participants.component'
import {ViewMainComponent} from './view-main/view-main.component'
import {ListGuestComponent} from './list-guest/list-guest.component'
import {CreateParticipantComponent} from './create-participant/create-participant.component'

export const ROUTES : Routes = [
    {path: '', component: ViewMainComponent},
    {path: 'list-participants', component: ListParticipantsComponent},
    {path: 'list-guest', component: ListGuestComponent},
    {path : 'create-participant', component: CreateParticipantComponent}
]