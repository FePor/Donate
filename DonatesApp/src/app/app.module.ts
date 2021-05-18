import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DonateAddComponent } from './components/donate-add/donate-add.component';
import { DonateListComponent } from './components/donate-list/donate-list.component';
import { MatInputModule } from  '@angular/material/input';
import { MatSelectModule } from  '@angular/material/select';
import { MatExpansionModule } from  '@angular/material/expansion';
import { MatFormFieldModule } from  '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import { CompaniesComponent } from './components/companies/companies.component';
@NgModule({
  declarations: [
    AppComponent,
    DonateAddComponent,
    DonateListComponent,
    CompaniesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatSelectModule,
    MatExpansionModule,
    HttpClientModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
