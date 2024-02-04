import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { User } from '../interfaces';
import { CommonModule } from '@angular/common';
import { DataService } from '../service/data.service';

@Component({
  selector: 'app-view-cv',
  standalone: true,
  imports: [CommonModule],
  styleUrl: './view-cv.component.css',
  templateUrl: './view-cv.component.html',
})

export class ViewCvComponent implements OnInit {
  user: User = {} as User;

  constructor(private data_service: DataService, private cd: ChangeDetectorRef) {}

  ngOnInit(): void {
      this.data_service.getUserData().subscribe({
        next: (data: User) => {
          this.user = data;
          this.cd.detectChanges();
        },
        error: (error: any) => {
          console.error('There was an error!', error);
        },
        complete: () => {
          console.log('Completed');
        }
      }
    );
  }
}
