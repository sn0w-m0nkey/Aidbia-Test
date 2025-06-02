<script setup lang="ts">
import { ref } from 'vue'

import ResumeDetail from './ResumeDetail.vue'

const expandedResumeId = ref<string | null>(null)

function toggleDetails(id: string) {
    expandedResumeId.value = expandedResumeId.value === id ? null : id
}

const props = defineProps({
    resumes: {
        type: Array,
        required: true
    }
})

</script>

<template>
    <table class="resume-table">
        <thead>
        <tr>
            <th>Full Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Summary</th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <template v-for="resume in resumes" :key="resume.id">
            <tr>
                <td>{{ resume.FullName }}</td>
                <td>{{ resume.PhoneNumber }}</td>
                <td>{{ resume.Email }}</td>
                <td>{{ resume.Description }}</td>
                <td class="actions-cell">
                    <button @click="toggleDetails(resume.id)">
                        {{ expandedResumeId === resume.FullName ? 'Hide' : 'Show' }}
                    </button>
                    <router-link :to="`/resumeView/${resume.Id}`">
                        <button>View CV</button>
                    </router-link>
                </td>
            </tr>

            <tr v-if="expandedResumeId === resume.id">
                <td colspan="6">
                    <ResumeDetail :resume="resume" />
                </td>
            </tr>
        </template>
        </tbody>
    </table>
</template>

<style scoped>
.resume-table {
    width: 100%;
    border-collapse: collapse;
    font-family: Arial, sans-serif;
    margin-top: 20px;
}

.resume-table th,
.resume-table td {
    border: 1px solid #ddd;
    padding: 12px 16px;
    text-align: left;
}

.resume-table th {
    background-color: #f2f2f2;
    font-weight: bold;
}

.resume-table tr:nth-child(even) {
    background-color: #fafafa;
}

.resume-table tr:hover {
    background-color: #f0f8ff;
}

.actions-cell {
    display: flex;
    gap: 8px;
}

.actions-cell button {
    padding: 6px 12px;
    font-size: 0.9rem;
    cursor: pointer;
    background-color: #005bbb;
    color: white;
    border: none;
    border-radius: 4px;
    transition: background-color 0.2s ease;
}

.actions-cell button:hover {
    background-color: #004099;
}

.expanded-row td {
    background-color: #f9f9f9;
}

.resume-detail {
     padding: 1rem;
     border-left: 4px solid #005bbb;
     background-color: #f9f9f9;
     border-radius: 8px;
     font-family: 'Segoe UI', Roboto, sans-serif;
     color: #333;
 }

.resume-detail h3 {
    margin-top: 1.5rem;
    margin-bottom: 0.5rem;
    color: #005bbb;
    font-size: 1.2rem;
    border-bottom: 1px solid #ccc;
    padding-bottom: 4px;
}

.resume-detail ul {
    list-style-type: none;
    padding-left: 0;
}

.resume-detail li {
    margin-bottom: 1rem;
    padding-left: 1rem;
    border-left: 3px solid #ddd;
}

.resume-detail li strong {
    display: block;
    font-size: 1rem;
    margin-bottom: 0.2rem;
}

.resume-detail a {
    color: #005bbb;
    text-decoration: underline;
    font-size: 0.9rem;
}

.badge {
    display: inline-block;
    background: #005bbb;
    color: white;
    padding: 4px 10px;
    margin: 0 6px 6px 0;
    font-size: 0.8rem;
    border-radius: 12px;
}


</style>
