import { Routes } from '@angular/router';
import { EditCvComponent } from './edit-cv/edit-cv.component';
import { ViewCvComponent } from './view-cv/view-cv.component';

export const routes: Routes = [
  { path: '', component: ViewCvComponent },
  {'path': 'edit', component: EditCvComponent},
];
