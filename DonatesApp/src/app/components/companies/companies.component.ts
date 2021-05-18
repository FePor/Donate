import { Component, OnInit } from '@angular/core';
import { Company,Item} from '@app/models';
import { CompanyService } from '@app/services/comany.service';
import { first } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
  companies!: Company[];
  countries!:Item[];
  currencies!:Item[];


  constructor(private companyService: CompanyService) {

      this.countries=[{label:"מדינה זרה",value:"1"},{label:"מדינה קרובה",value:"2"}];
      this.currencies=[{label:"דולר",value:"1"},{label:"סוג 2",value:"2"}];
       
  }

  ngOnInit() {

      this.companyService.getAll().pipe(
          take(1)
        ).subscribe(res=>{
          this.companies=res;
        })
  }

   save(item:Company) {
      this.companyService.update(item.id.toString(), item)
          .pipe(first())
          .subscribe(() => {
              window.alert('Company updated');
          })
  }
 
      
    
    delete(item:Company){
      
      
    }
}