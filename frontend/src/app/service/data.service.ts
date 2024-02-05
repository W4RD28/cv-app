import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Certification, Language, Skill, Social, User, Work, Project, Education } from '../interfaces';
import { CreateCertificationDto, CreateEducationDto, CreateLanguageDto, CreateProjectDto, CreateSkillDto, CreateSocialDto,
  CreateWorkDto, UpdateCertificationDto, UpdateEducationDto, UpdateLanguageDto, UpdateProjectDto, UpdateSkillDto, UpdateSocialDto, UpdateWorkDto } from '../dtos';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  apiUrl = 'http://localhost:5262/api/';
  constructor(private http: HttpClient) { }

  getUserData(): Observable<User> {
    return this.http.get<User>(this.apiUrl + 'user/1');
  }

  updateUserData(user: User): Observable<User> {
    const params = {
      name: user.name,
      label: user.label,
      email: user.email,
      phone: user.phone,
      location: user.location,
      summary: user.summary,
      website: user.website,
    }
    return this.http.put<User>(this.apiUrl + 'user/1', params);
  }

  createCertifificateData(cert: CreateCertificationDto): Observable<Certification> {
    return this.http.post<Certification>(this.apiUrl + 'certification', cert);
  }

  createSkillData(skill: CreateSkillDto): Observable<Skill> {
    return this.http.post<Skill>(this.apiUrl + 'skill', skill);
  }

  createLanguageData(lang: CreateLanguageDto): Observable<CreateLanguageDto> {
    return this.http.post<CreateLanguageDto>(this.apiUrl + 'language', lang);
  }

  createWorkData(work: CreateWorkDto): Observable<CreateWorkDto> {
    return this.http.post<CreateWorkDto>(this.apiUrl + 'work', work);
  }

  createSocialData(social: CreateSocialDto): Observable<Social> {
    return this.http.post<Social>(this.apiUrl + 'social', social);
  }

  createProjectData(project: CreateProjectDto): Observable<Project> {
    return this.http.post<Project>(this.apiUrl + 'project', project);
  }

  createEducationData(education: CreateEducationDto): Observable<Education> {
    return this.http.post<Education>(this.apiUrl + 'education', education);
  }

  updateCertificationData(cert: UpdateCertificationDto): Observable<Certification> {
    return this.http.put<Certification>(this.apiUrl + 'certification/' + cert.id, cert);
  }

  updateSkillData(skill: UpdateSkillDto): Observable<Skill> {
    return this.http.put<Skill>(this.apiUrl + 'skill/' + skill.id, skill);
  }

  updateLanguageData(lang: UpdateLanguageDto): Observable<Language> {
    return this.http.put<Language>(this.apiUrl + 'language/' + lang.id, lang);
  }

  updateWorkData(work: UpdateWorkDto): Observable<Work> {
    return this.http.put<Work>(this.apiUrl + 'work/' + work.id, work);
  }

  updateSocialData(social: UpdateSocialDto): Observable<Social> {
    return this.http.put<Social>(this.apiUrl + 'social/' + social.id, social);
  }

  updateProjectData(project: UpdateProjectDto): Observable<Project> {
    return this.http.put<Project>(this.apiUrl + 'project/' + project.id, project);
  }

  updateEducationData(education: UpdateEducationDto): Observable<Education> {
    return this.http.put<Education>(this.apiUrl + 'education/' + education.id, education);
  }

  deleteCertificationData(id: number): Observable<Certification> {
    return this.http.delete<Certification>(this.apiUrl + 'certification/' + id);
  }

  deleteSkillData(id: number): Observable<Skill> {
    return this.http.delete<Skill>(this.apiUrl + 'skill/' + id);
  }

  deleteLanguageData(id: number): Observable<Language> {
    return this.http.delete<Language>(this.apiUrl + 'language/' + id);
  }

  deleteWorkData(id: number): Observable<Work> {
    return this.http.delete<Work>(this.apiUrl + 'work/' + id);
  }

  deleteSocialData(id: number): Observable<Social> {
    return this.http.delete<Social>(this.apiUrl + 'social/' + id);
  }

  deleteProjectData(id: number): Observable<Project> {
    return this.http.delete<Project>(this.apiUrl + 'project/' + id);
  }

  deleteEducationData(id: number): Observable<Education> {
    return this.http.delete<Education>(this.apiUrl + 'education/' + id);
  }
}
