import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonateAddComponent } from './components/donate-add/donate-add.component';
import { CompaniesComponent } from './components/companies/companies.component';

const routes: Routes = [
  { path: '', component: DonateAddComponent },
  { path: 'companies', component:CompaniesComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
