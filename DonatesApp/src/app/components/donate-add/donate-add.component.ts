import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { CompanyService } from '@app/services/comany.service';

@Component({
  selector: 'app-donate-add',
  templateUrl: './donate-add.component.html',
  styleUrls: ['./donate-add.component.css']
})
export class DonateAddComponent implements OnInit {
  form!: FormGroup;
  id!: string;
  isAddMode!: boolean;
  loading = false;
  submitted = false;
  constructor( private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private companyService: CompanyService) { }

  ngOnInit(): void {
  

  this.id = this.route.snapshot.params['id'];
  this.isAddMode = !this.id;
  
 

  
  const formOptions: AbstractControlOptions = {  };
  this.form = this.formBuilder.group({
      type: ['', Validators.required],
      name: ['', [Validators.required,Validators.pattern("^[a-z\\u0590-\\u05fe ]+$")]],
      amount: ['', [Validators.required,Validators.pattern("^\\d+(\\.\\d{1,2})?$")]],
      details: ['', [Validators.required,Validators.pattern("^[a-z\\u0590-\\u05fe ]+$")]],
      conditions: ['',Validators.pattern("^[a-z\\u0590-\\u05fe ]+$") ],
      currency: ['', Validators.required],
      rate: ['',[ Validators.required,Validators.pattern("^\\d+(\\.\\d{1,2})?$")]]

    }, formOptions);

  
}

get f() { return this.form.controls; }

onSubmit() {
  this.submitted = true;
  if (this.form.invalid) {
      return;
  }

  this.loading = true;
      this.createCompany();
}
public reset() {
  this.form.reset();
}
private createCompany() {
  this.companyService.create(this.form.value)
      .pipe(first())
      .subscribe(() => {
          this.router.navigate(['../companies'], { relativeTo: this.route });
      })
      .add(() => this.loading = false);
}


}
