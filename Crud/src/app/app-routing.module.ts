import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublicComponent } from './pages/public/public/public.component';
import { MainComponent } from './pages/public/main/main.component';

// A rota com ** sempre DEVERA ser a ultima;
const routes: Routes = [
  { path: '**', component: PublicComponent },
// { path: '**', redirectTo:'veiculos', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
