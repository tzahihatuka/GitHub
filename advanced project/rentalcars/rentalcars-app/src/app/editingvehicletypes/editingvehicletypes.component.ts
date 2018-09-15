import { Component, OnInit } from '@angular/core';
import { carsService } from '../shared/services/cars-serves';
import { carsModel } from '../shared/services/car-model-Serves';
import { branchservice } from '../shared/services/branch-Service';
import { UploadImageService } from '../shared/services/upload-image.service';
@Component({
  selector: 'editingvehicletypes',
  templateUrl: './editingvehicletypes.component.html',
  styleUrls: ['./editingvehicletypes.component.css']
})
export class EditingvehicletypesComponent  {
  model:any={a:""};
  carGallery:any={a:""};
  TypsModel:any={a:""};
  TypsGetGear:any={a:""};
  TypsGetYear:any={a:Date};
  newCarType:any={a:""};
  constructor(private myCar:carsService,private myCarModel:carsModel,private myBranchs:branchservice,private imageService: UploadImageService ) {
    this.myCarModel.getCarTyps();
    this.carGallery=this.myCarModel.TypeName;
    this.TypsModel=this.myCarModel.TypsModel;
this.TypsGetGear=this.myCarModel.TypsGetGear;
this.TypsGetYear=this.myCarModel.TypsGetYear;
  }
  Company:string;
  saverange(){
    this.myCarModel.getCarTypsModel(this.Company);
    this.model.ManufacturerName=this.Company;
    this.model.IsProperForRent=true;
  }

  search(){
    this.myCarModel.getCarTypsbyNameModelGear(this.model);
  }


}