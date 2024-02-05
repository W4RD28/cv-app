import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../interfaces';
import { DataService } from '../service/data.service';
import { ReactiveFormsModule, FormControl, FormGroup, FormArray, FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UpdateSkillDto, UpdateWorkDto } from '../dtos';


@Component({
  selector: 'app-edit-cv',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './edit-cv.component.html',
  styleUrl: './edit-cv.component.css'
})
export class EditCvComponent implements OnInit {
  userForm!: FormGroup;

  constructor(private data_service: DataService, private cd: ChangeDetectorRef,
    private fb: FormBuilder, public router: Router) {}

  reloadComponent(self:boolean,urlToNavigateTo ?:string){
    //skipLocationChange:true means dont update the url to / when navigating
    console.log("Current route I am on:",this.router.url);
    const url=self ? this.router.url :urlToNavigateTo;
    this.router.navigateByUrl('/',{skipLocationChange:true}).then(()=>{
      this.router.navigate([`/${url}`]).then(()=>{
        console.log(`After navigation I am on:${this.router.url}`)
      })
    })
  }


  ngOnInit(): void {
      this.data_service.getUserData().subscribe({
        next: (data: User) => {
          this.userForm = this.fb.group({
            user: this.fb.group({
              name: data.name,
              label: data.label,
              email: data.email,
              phone: data.phone,
              location: data.location,
              summary: data.summary,
              website: data.website,
            }),
            skills: this.fb.array(
              (data.skills ?? []).map((skill) => this.fb.group(skill))
            ),
            languages: this.fb.array(
              (data.languages ?? []).map((language) => this.fb.group(language))
            ),
            socials: this.fb.array(
              (data.socials ?? []).map((social) => this.fb.group(social))
            ),
            works: this.fb.array(
              (data.works ?? []).map((work) => this.fb.group(work))
            ),
            educations: this.fb.array(
              (data.educations ?? []).map((education) => this.fb.group(education))
            ),
            projects: this.fb.array(
              (data.projects ?? []).map((project) => this.fb.group(project))
            ),
            certifications: this.fb.array(
              (data.certifications ?? []).map((certification) => this.fb.group(certification))
            ),
          });
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
  get skills() {
    return this.userForm.get('skills') as FormArray;
  }
  get languages() {
    return this.userForm.get('languages') as FormArray;
  }
  get socials() {
    return this.userForm.get('socials') as FormArray;
  }
  get works() {
    return this.userForm.get('works') as FormArray;
  }
  get educations() {
    return this.userForm.get('educations') as FormArray;
  }
  get projects() {
    return this.userForm.get('projects') as FormArray;
  }
  get certifications() {
    return this.userForm.get('certifications') as FormArray;
  }

  addSkill() {
    var skill = { name: '', userId: 1 }
    var data = this.data_service.createSkillData(skill).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.skills.push(this.fb.group(data));
    this.reloadComponent(true);
  }

  addLanguage() {
    let languageData: any;
    this.data_service.createLanguageData({ name: '', userId: 1, proficiency: '' }).subscribe({
      next: (data: any) => {
        languageData = data;
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.languages.push(this.fb.group(languageData));
    this.reloadComponent(true);
  }

  addWork() {
    this.data_service.createWorkData({ company: '', position: '', startDate: new Date().toString(),
    endDate: new Date().toString(), description: '', location: '', userId: 1 }).subscribe({
      next: (data: any) => {
        var data = data;
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.works.push(this.fb.group({ company: '', position: '', startDate: new Date().toString(),
    endDate: new Date().toString(), description: '', location: '', userId: 1 }));
    this.reloadComponent(true);
  }

  addEducation() {
    this.educations.push(this.fb.group({ institution: '', area: '',
    studyType: '', startDate: new Date().toString(), endDate: new Date().toString(), userId: 1 }));
    this.data_service.createEducationData({ institution: '', area: '',
    studyType: '', startDate: new Date().toString(), endDate: new Date().toString(), userId: 1 }).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.reloadComponent(true);
  }

  addSocial() {
    this.socials.push(this.fb.group({ name: '', url: '', userId: 1 }));
    this.data_service.createSocialData({ name: '', url: '', userId: 1 }).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.reloadComponent(true);
  }

  addCertification() {
    this.certifications.push(this.fb.group({ name: '', authority: '',
    description: '', licenseNumber: '', url: '', date: '',
    userId: 1 }));
    this.data_service.createCertifificateData({ name: '', authority: '',
    description: '', licenseNumber: '', url: '', date: new Date().toString(),
    userId: 1 }).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.reloadComponent(true);
  }

  addProject() {
    this.projects.push(this.fb.group({ name: '', description: '', url: '',
    startDate: new Date().toString(), endDate: new Date().toString(), userId: 1 }));
    this.data_service.createProjectData({ name: '', description: '', url: '',
    startDate: new Date().toString(), endDate: new Date().toString(), userId: 1 }).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.reloadComponent(true);
  }

  updateUser() {
    console.log(this.userForm.value);
    const user = this.userForm.get('user');
    if (user) {
      this.data_service.updateUserData(user.value).subscribe({
        next: (data: User) => {
          console.log(data);
        },
        error: (error: any) => {
          console.error('There was an error!', error);
        },
        complete: () => {
          console.log('Completed');
        }
      });
    }
    alert('User updated');
  }

  updateSkill(index: number) {
    const skill = this.skills.at(index);
    const skillDto: UpdateSkillDto = {
      name: skill.value.name,
      id: skill.value.id,
    };
    this.data_service.updateSkillData(skillDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.skills.at(index).patchValue({ name: skillDto.name });
    alert('Skill updated');
  }

  updateLanguage(index: number) {
    const language = this.languages.at(index);
    const languageDto = {
      name: language.value.name,
      id: language.value.id,
      proficiency: language.value.proficiency,
    };
    this.data_service.updateLanguageData(languageDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.languages.at(index).patchValue({ name: languageDto.name, proficiency: languageDto.proficiency });
    alert('Language updated');
  }

  updateWork(index: number) {
    const work = this.works.at(index);
    const workDto: UpdateWorkDto = {
      company: work.value.company,
      position: work.value.position,
      location: work.value.location,
      startDate: work.value.startDate,
      endDate: work.value.endDate,
      description: work.value.description,
      id: work.value.id,
    };
    this.data_service.updateWorkData(workDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.works.at(index).patchValue({ company: workDto.company, position: workDto.position,
      location: workDto.location, startDate: workDto.startDate, endDate: workDto.endDate,
      description: workDto.description });
    alert('Work updated');
  }

  setWorkEndDate(index: number) {
    const work = this.works.at(index);
    const workDto: UpdateWorkDto = {
      company: work.value.company,
      position: work.value.position,
      location: work.value.location,
      startDate: work.value.startDate,
      endDate: new Date().toString(),
      description: work.value.description,
      id: work.value.id,
    };
    this.data_service.updateWorkData(workDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.works.at(index).patchValue({ endDate: Date.now() });
  }

  setWorkEndDateToNull(index: number) {
    this.works.at(index).patchValue({ endDate: null });
  }

  updateEducation(index: number) {
    const education = this.educations.at(index);
    const educationDto = {
      institution: education.value.institution,
      area: education.value.area,
      studyType: education.value.studyType,
      startDate: education.value.startDate,
      endDate: education.value.endDate,
      gpa: education.value.gpa,
      id: education.value.id,
    };
    this.data_service.updateEducationData(educationDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.educations.at(index).patchValue({ institution: educationDto.institution, area: educationDto.area,
      studyType: educationDto.studyType, startDate: educationDto.startDate, endDate: educationDto.endDate });
    alert('Education updated');
  }

  setEducationEndDate(index: number) {
    this.educations.at(index).patchValue({ endDate: Date.now() });
  }

  setEducationEndDateToNull(index: number) {
    this.educations.at(index).patchValue({ endDate: null });
  }

  updateSocial(index: number) {
    const social = this.socials.at(index);
    const socialDto = {
      name: social.value.name,
      id: social.value.id,
      url: social.value.url,
    };
    this.data_service.updateSocialData(socialDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.socials.at(index).patchValue({ name: socialDto.name, url: socialDto.url });
    alert('Social updated');
  }

  updateCertification(index: number) {
    const data = this.certifications.at(index).value;
    const certDto = {
      name: data.name,
      authority: data.authority,
      licenseNumber: data.licenseNumber,
      date: data.date,
      expirationDate: data.expirationDate,
      url: data.url,
      description: data.description,
      id: data.id,
    };
    this.data_service.updateCertificationData(certDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.certifications.at(index).patchValue({ name: certDto.name, authority: certDto.authority,
      licenseNumber: certDto.licenseNumber, date: certDto.date, expirationDate: certDto.expirationDate,
      url: certDto.url, description: certDto.description });
    alert('Certification updated');
  }

  setCertificationExpirationDate(index: number) {
    this.certifications.at(index).patchValue({ endDate: Date.now() });
  }

  setCertificationExpirationDateToNull(index: number) {
    this.certifications.at(index).patchValue({ endDate: null });
  }

  updateProject(index: number) {
    const data = this.projects.at(index).value;
    const projectDto = {
      name: data.name,
      description: data.description,
      url: data.url,
      startDate: data.startDate,
      endDate: data.endDate,
      id: data.id,
    };
    this.data_service.updateProjectData(projectDto).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.projects.at(index).patchValue({ name: projectDto.name, description: projectDto.description,
      url: projectDto.url, startDate: projectDto.startDate, endDate: projectDto.endDate });
    alert('Project updated');
  }

  setProjectEndDate(index: number) {
    this.projects.at(index).patchValue({ endDate: Date.now() });
  }

  setProjectEndDateToNull(index: number) {
    this.projects.at(index).patchValue({ endDate: null });
  }

  removeSkill(index: number) {
    const id = this.skills.at(index).value.id;
    this.data_service.deleteSkillData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.skills.removeAt(index);
    alert('Skill removed');
  }

  removeLanguage(index: number) {
    const id = this.languages.at(index).value.id;
    this.data_service.deleteLanguageData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.languages.removeAt(index);
    alert('Language removed');
  }

  removeWork(index: number) {
    const id = this.works.at(index).value.id;
    this.data_service.deleteWorkData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.works.removeAt(index);
    alert('Work removed');
  }

  removeEducation(index: number) {
    const id = this.educations.at(index).value.id;
    this.data_service.deleteEducationData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.educations.removeAt(index);
    alert('Education removed');
  }

  removeSocial(index: number) {
    const id = this.socials.at(index).value.id;
    this.data_service.deleteSocialData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.socials.removeAt(index);
    alert('Social removed');
  }

  removeCertification(index: number) {
    const id = this.certifications.at(index).value.id;
    this.data_service.deleteCertificationData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.certifications.removeAt(index);
    alert('Certification removed');
  }

  removeProject(index: number) {
    const id = this.projects.at(index).value.id;
    this.data_service.deleteProjectData(id).subscribe({
      next: (data: any) => {
        console.log(data);
      },
      error: (error: any) => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
    this.projects.removeAt(index);
    alert('Project removed');
  }
}
