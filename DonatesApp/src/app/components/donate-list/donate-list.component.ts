import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Company,Item} from '@app/models';

@Component({
  selector: 'app-donate-list',
  templateUrl: './donate-list.component.html',
  styleUrls: ['./donate-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DonateListComponent implements OnInit {
  @Input() list!:Company[];
data!:Company[];
@Input() countries!:Item[];
@Input() currencies!:any[];
@Output() save: EventEmitter<Company>= new EventEmitter<Company>();
@Output() delete: EventEmitter<Company>= new EventEmitter<Company>();

countryTypeControl= new FormControl('');
currencyControl=new FormControl('');
constructor() {
 
 }
ngOnChanges(changes: SimpleChanges): void {
   this.data=[];
 this.list.forEach(val => this.data.push(Object.assign({},val)));
}

ngOnInit() {
}


}
