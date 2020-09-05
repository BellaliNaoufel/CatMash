import { CatvoteComponent } from './Components/catvote/catvote.component';
import { CatlistComponent } from './Components/catlist/catlist.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'catlist', component: CatlistComponent },
  { path: 'catvote', component: CatvoteComponent },
  { path: '', redirectTo: '/catlist',
  pathMatch: 'full'
},
{ path: '**', redirectTo: 'catlist' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
