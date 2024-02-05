export interface CreateSkillDto {
  name: string;
  userId: number;
}

export interface CreateLanguageDto {
  name: string;
  userId: number;
  proficiency: string;
}

export interface UpdateSkillDto {
  name: string;
  id: number;
}

export interface UpdateLanguageDto {
  name: string;
  id: number;
  proficiency: string;
}

export interface CreateWorkDto {
  company: string;
  position: string;
  startDate: string;
  endDate?: string;
  description: string;
  location: string;
  userId: number;
}

export interface UpdateWorkDto {
  company: string;
  position: string;
  startDate: string;
  endDate?: string;
  description: string;
  location: string;
  id: number;
}

export interface CreateSocialDto {
  name: string;
  url: string;
  userId: number;
}

export interface UpdateSocialDto {
  name: string;
  url: string;
  id: number;
}

export interface CreateCertificationDto {
  name: string;
  authority: string;
  licenseNumber: string;
  date: string;
  expirationDate?: string;
  url: string;
  description: string;
  userId: number;
}

export interface UpdateCertificationDto {
  name: string;
  authority: string;
  licenseNumber: string;
  date: string;
  expirationDate?: string;
  url: Date;
  description: string;
  id: number;
}

export interface CreateProjectDto {
  name: string;
  description: string;
  url: string;
  startDate: string;
  endDate?: string;
  userId: number;
}

export interface UpdateProjectDto {
  name: string;
  description: string;
  url: string;
  startDate: string;
  endDate?: string;
  id: number;
}

export interface CreateEducationDto {
  institution: string;
  area: string;
  studyType: string;
  gpa?: number;
  startDate: string;
  endDate?: string;
  userId: number;
}

export interface UpdateEducationDto {
  institution: string;
  area: string;
  studyType: string;
  gpa: number;
  startDate: string;
  endDate?: string;
  id: number;
}
