<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import type { Resume } from 'types/Resume'
import { resumes } from '~@/views/general/data/resumes'

const route = useRoute()
const resume = ref<Resume | null>(null)

onMounted(() => {
    const id = Number(route.params.id)
    resume.value = resumes.find(r => r.Id === id) || null
    console.log(resume)
})
</script>

<template>
    <div v-if="resume" class="cv-container">
        <div class="cv-header">
            <h1>{{ resume.FullName }}'s CV</h1>
            <div class="cv-contact">
                <p><strong>Email:</strong> {{ resume.Email }}</p>
                <p><strong>Phone:</strong> {{ resume.PhoneNumber }}</p>
            </div>
        </div>

        <div class="cv-summary">
            <strong>Summary:</strong> {{ resume.Summary }}
        </div>

        <div class="cv-description">
            <strong>Description:</strong> {{ resume.Description }}
        </div>

        <div class="cv-section">
            <h2>Experience</h2>
            <ul>
                <li v-for="exp in resume.Experiences" :key="exp.CompanyName">
                    <strong>{{ exp.Position }}</strong> at {{ exp.CompanyName }}<br />
                    {{ exp.StartDate?.split('T')[0] }} - {{ exp.EndDate ? exp.EndDate.split('T')[0] : 'Present' }}<br />
                    <em>{{ exp.Description }}</em><br />
                    <a :href="exp.Website" target="_blank">{{ exp.Website }}</a>
                </li>
            </ul>
        </div>

        <div class="cv-section">
            <h2>Education</h2>
            <ul>
                <li v-for="edu in resume.Educations" :key="edu.Institution">
                    <strong>{{ edu.Qualification }}</strong> - {{ edu.Institution }}<br />
                    {{ edu.StartDate?.split('T')[0] }} to {{ edu.EndDate?.split('T')[0] }}
                </li>
            </ul>
        </div>
    </div>

    <div v-else>
        <p>Resume not found.</p>
    </div>
</template>


<style scoped>
.cv-container {
    max-width: 800px;
    margin: 2rem auto;
    padding: 2rem;
    background: white;
    border-radius: 10px;
    border: 1px solid #ddd;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.05);
    font-family: 'Segoe UI', Roboto, sans-serif;
    color: #333;
}

.cv-header {
    border-bottom: 2px solid #005bbb;
    padding-bottom: 1rem;
    margin-bottom: 1.5rem;
}

.cv-header h1 {
    margin: 0;
    font-size: 2rem;
    color: #005bbb;
}

.cv-contact p {
    margin: 0.3rem 0;
    font-size: 0.95rem;
}

.cv-section {
    margin-bottom: 2rem;
}

.cv-section h2 {
    font-size: 1.4rem;
    margin-bottom: 1rem;
    border-bottom: 1px solid #ccc;
    padding-bottom: 0.3rem;
    color: #333;
}

.cv-section ul {
    padding-left: 1rem;
    list-style-type: none;
}

.cv-section li {
    margin-bottom: 1rem;
    padding-left: 1rem;
    border-left: 3px solid #ddd;
}

.cv-section li strong {
    display: block;
}

.cv-summary,
.cv-description {
    margin: 1rem 0;
    padding: 0.75rem;
    background: #f9f9f9;
    border-left: 4px solid #ccc;
    border-radius: 4px;
    font-style: italic;
}
</style>

